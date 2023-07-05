using System;
using System.Collections.Generic;
using ET.Client;

using TrueSync;
using Unity.Mathematics;

namespace ET
{
    [FriendOf(typeof(MoveComponent))]
    public static class MoveComponentSystem
    {
        [Invoke(TimerInvokeType.MoveTimer)]
        public class MoveTimer: ATimer<MoveComponent>
        {
            protected override void Run(MoveComponent self)
            {
                try
                {
                    self.MoveForward(true);
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }
    
        [ObjectSystem]
        public class DestroySystem: DestroySystem<MoveComponent>
        {
            protected override void Destroy(MoveComponent self)
            {
                self.MoveFinish(true);
            }
        }

        [ObjectSystem]
        public class AwakeSystem: AwakeSystem<MoveComponent>
        {
            protected override void Awake(MoveComponent self)
            {
                self.StartTime = 0;
                self.StartPos = TSVector.zero;
                self.NeedTime = 0;
                self.MoveTimer = 0;
                self.tcs = null;
                self.Targets.Clear();
                self.Speed = 0;
                self.N = 0;
                self.TurnTime = 0;
            }
        }
        
        public static bool IsArrived(this MoveComponent self)
        {
            return self.Targets.Count == 0;
        }

        public static bool ChangeSpeed(this MoveComponent self, FP speed)
        {
            if (self.IsArrived())
            {
                return false;
            }

            if (speed < 0.0001)
            {
                return false;
            }
            
            Creature unit = self.GetParent<Creature>();

            using ListComponent<TSVector> path = ListComponent<TSVector>.Create();
            
            self.MoveForward(false);
                
            path.Add(unit.Position); // 第一个是Unit的pos
            for (int i = self.N; i < self.Targets.Count; ++i)
            {
                path.Add(self.Targets[i]);
            }
            self.MoveToAsync(path, speed).Coroutine();
            return true;
        }

        // 该方法不需要用cancelToken的方式取消，因为即使不传入cancelToken，多次调用该方法也要取消之前的移动协程,上层可以stop取消
        public static async ETTask<bool> MoveToAsync(this MoveComponent self, List<TSVector> target, FP speed, int turnTime = 0)
        {
            self.Stop(false);

            foreach (TSVector v in target)
            {
                self.Targets.Add(v);
            }

            self.IsTurnHorizontal = true;
            self.TurnTime = turnTime;
            self.Speed = speed;
            self.tcs = ETTask<bool>.Create(true);

            EventSystem.Instance.Publish(self.DomainScene(), new Evt_MoveStart() {Creature = self.GetParent<Creature>()});
            
            self.StartMove();
            
            bool moveRet = await self.tcs;

            if (moveRet)
            {
                EventSystem.Instance.Publish(self.DomainScene(), new Evt_MoveStop() {Creature = self.GetParent<Creature>()});
            }
            return moveRet;
        }

        // ret: 停止的时候，移动协程的返回值
        private static void MoveForward(this MoveComponent self, bool ret)
        {
            Creature unit = self.GetParent<Creature>();
            
            long timeNow = TimeHelper.ClientNow();
            long moveTime = timeNow - self.StartTime;

            while (true)
            {
                if (moveTime <= 0)
                {
                    return;
                }
                
                // 计算位置插值
                if (moveTime >= self.NeedTime)
                {
                    unit.Position = self.NextTarget;
                    if (self.TurnTime > 0)
                    {
                        unit.Rotation = self.To;
                    }
                }
                else
                {
                    // 计算位置插值
                    FP amount = moveTime * 1f / self.NeedTime;
                    if (amount > 0)
                    {
                        // TSVector newPos = math.lerp(self.StartPos, self.NextTarget, amount);
                        TSVector newPos = TSVector.Lerp(self.StartPos, self.NextTarget, amount);
                        unit.Position = newPos;
                    }
                    
                    // 计算方向插值
                    if (self.TurnTime > 0)
                    {
                        amount = moveTime * 1f / self.TurnTime;
                        if (amount > 1)
                        {
                            amount = 1f;
                        }
                        // quaternion q = math.slerp(self.From, self.To, amount);
                        TSQuaternion q = TSQuaternion.Slerp(self.From, self.To, amount);
                        unit.Rotation = q;
                    }
                }

                moveTime -= self.NeedTime;

                // 表示这个点还没走完，等下一帧再来
                if (moveTime < 0)
                {
                    return;
                }
                
                // 到这里说明这个点已经走完
                
                // 如果是最后一个点
                if (self.N >= self.Targets.Count - 1)
                {
                    unit.Position = self.NextTarget;
                    unit.Rotation = self.To;

                    self.MoveFinish(ret);
                    return;
                }

                self.SetNextTarget();
            }
        }

        private static void StartMove(this MoveComponent self)
        {
            self.BeginTime = TimeHelper.ClientNow();
            self.StartTime = self.BeginTime;
            self.SetNextTarget();

            self.MoveTimer = TimerComponent.Instance.NewFrameTimer(TimerInvokeType.MoveTimer, self);
        }

        private static void SetNextTarget(this MoveComponent self)
        {

            Creature unit = self.GetParent<Creature>();

            ++self.N;

            // 时间计算用服务端的位置, 但是移动要用客户端的位置来插值
            TSVector v = self.GetFaceV();
            // float distance = math.length(v);
            FP distance = v.magnitude;

            
            // 插值的起始点要以unit的真实位置来算
            self.StartPos = unit.Position;

            self.StartTime += self.NeedTime;
            
            self.NeedTime = (long) (distance / self.Speed * 1000);
            
            if (self.TurnTime > 0)
            {
                // 要用unit的位置
                TSVector faceV = self.GetFaceV();
                //if (math.lengthsq(faceV) < 0.0001f)
                if(TSVector.Dot(faceV,faceV) < 0.0001f)
                {
                    return;
                }
                self.From = unit.Rotation;
                
                if (self.IsTurnHorizontal)
                {
                    faceV.y = 0;
                }

                if (TSMath.Abs(faceV.x) > 0.01 || TSMath.Abs(faceV.z) > 0.01)
                {
                    self.To = TSQuaternion.LookRotation(faceV, TSVector.up);
                }

                return;
            }
            
            if (self.TurnTime == 0) // turn time == 0 立即转向
            {
                TSVector faceV = self.GetFaceV();
                if (self.IsTurnHorizontal)
                {
                    faceV.y = 0;
                }

                if (TSMath.Abs(faceV.x) > 0.01 || TSMath.Abs(faceV.z) > 0.01)
                {
                    self.To = TSQuaternion.LookRotation(faceV, TSVector.up);
                    unit.Rotation = self.To;
                }
            }
        }

        private static TSVector GetFaceV(this MoveComponent self)
        {
            return self.NextTarget - self.PreTarget;
        }

        public static bool FlashTo(this MoveComponent self, TSVector target)
        {
            Creature unit = self.GetParent<Creature>();
            unit.Position = target;
            return true;
        }

        // ret: 停止的时候，移动协程的返回值
        public static void Stop(this MoveComponent self, bool ret)
        {
            if (self.Targets.Count > 0)
            {
                self.MoveForward(ret);
            }

            self.MoveFinish(ret);
        }

        private static void MoveFinish(this MoveComponent self, bool ret)
        {
            if (self.StartTime == 0)
            {
                return;
            }
            
            self.StartTime = 0;
            self.StartPos = TSVector.zero;
            self.BeginTime = 0;
            self.NeedTime = 0;
            TimerComponent.Instance?.Remove(ref self.MoveTimer);
            self.Targets.Clear();
            self.Speed = 0;
            self.N = 0;
            self.TurnTime = 0;
            self.IsTurnHorizontal = false;

            if (self.tcs != null)
            {
                var tcs = self.tcs;
                self.tcs = null;
                tcs.SetResult(ret);
            }
        }
    }
}