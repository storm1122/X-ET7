using System.Collections.Generic;
using ET.Client.BattleEvent;
using TrueSync;

namespace ET.Client
{


    [Event(SceneType.Current)]
    public class Evt_MovePathEndHandler: AEvent<Scene, Evt_MoveStop>
    {
        protected override async ETTask Run(Scene scene, Evt_MoveStop a)
        {
            if (scene.Name != ConstValue.BattleSceneName)
            {
                return;
            }
            var footHoldComponent = scene.GetComponent<FootHoldComponent>();
            if (footHoldComponent == null)
            {
                return;
            }

            if (a.Creature.InstanceId != CreatureHelper.GetCaster(scene)?.InstanceId)
            {
                return;
            }
            

            footHoldComponent.EnterFootHold().Coroutine();

            await ETTask.CompletedTask;
        }
    }
    
    [ObjectSystem]
    [FriendOfAttribute(typeof(ET.Client.FootHold))]
    public class FootHoldComponentAwakeSystem : AwakeSystem<FootHoldComponent, int, int>
    {
        protected override void Awake(FootHoldComponent self, int configId, int startIdx)
        {
            self.ConfigId = configId;

            self.CurPathIdx = startIdx;
            
            self.CastMovePath = new List<TSVector>();
            
            for (int i = 0; i < self.Config.SpawnInfos.Length; i++)
            {
                // 创建
                var footHold = self.AddChildWithId<FootHold, int>(i, i);
            }

        }
    }

    [ObjectSystem]
    public class FootHoldComponentDestorySystem: DestroySystem<FootHoldComponent>
    {
        protected override void Destroy(FootHoldComponent self)
        {
            self.CastMovePath.Clear();
        }
    }
    [FriendOfAttribute(typeof(ET.Client.FootHoldComponent))]
    public static class FootHoldComponentSystem
    {
        public static FootHold GetCurFootHold(this FootHoldComponent self)
        {
            var footHold = self.GetChild<FootHold>(self.CurPathIdx);
            return footHold;
        }

        //正常通关，需要刷守关怪物
        public static async ETTask EnterFootHold(this FootHoldComponent self)
        {
            var footHold = self.GetCurFootHold();

            if (footHold == null)
            {
                Log.Error($"当前关卡获取错误!");
                return;
            }

            //刷守关怪
            footHold.SpawnGuide();
            
            var allEnemy = CreatureHelper.GetCreature(self.DomainScene(), Camp.B);
            if (allEnemy.Count > 0)
            {
                await self.DomainScene().GetComponent<CreatureComponent>().GetComponent<ObjectWait>().Wait<Wait_KillAllCampB>();
            }
            
            self.CurPathIdx++;

            self.Start();
        }
       

        public static void Start(this FootHoldComponent self)
        {
            
            var footHold = self.GetCurFootHold();

            if (footHold == null)
            {
                //todo 战斗通关
                Log.Console($"战斗通关!");
                self.DomainScene().GetComponent<BattleComponent>().BattleEnd();
                return;
            }
            
            var castle = self.DomainScene().GetComponent<CreatureComponent>().Castle;

            Log.Console($"开始移动到下一个据点 idx：{self.CurPathIdx}, pos:{castle.Position.ToString()}");
      
            MoveCastle.StartMove(self.DomainScene());
            
            self.GetCurFootHold()?.SpawnNormal();
        }
        
        



        
        
    }
    
}