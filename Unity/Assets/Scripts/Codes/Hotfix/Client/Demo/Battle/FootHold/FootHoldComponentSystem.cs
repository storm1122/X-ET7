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
    public class FootHoldComponentAwakeSystem : AwakeSystem<FootHoldComponent, int>
    {
        protected override void Awake(FootHoldComponent self, int configId)
        {
            self.ConfigId = configId;
            
            self.CastMovePath = new List<TSVector>();
            
            self.CurPathIdx = -1;

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
            self.CurPathIdx = -1;
            self.CastMovePath.Clear();
        }
    }
    [FriendOfAttribute(typeof(ET.Client.FootHoldComponent))]
    public static class FootHoldComponentSystem
    {
        public static void SpawnCurEnemy(this FootHoldComponent self)
        {
            var footHold = self.GetChild<FootHold>(self.CurPathIdx);

            if (footHold == null)
            {
                return;
            }

            foreach ((long key, Entity value) in footHold.Children)
            {
                SpawnComponent spawnComponent = (SpawnComponent)value;
                spawnComponent.WaitSpawn();
            }
        }

        public static async ETTask EnterFootHold(this FootHoldComponent self)
        {
            self.CurPathIdx++;
            
            var castle = self.DomainScene().GetComponent<CreatureComponent>().Castle;

            Log.Console($"进入据点 idx：{self.CurPathIdx}, pos:{castle.Position.ToString()}");

            var enemys = CreatureHelper.GetCreature(self.DomainScene(), Camp.B);

            if (enemys.Count > 0)
            {
                await self.DomainScene().GetComponent<CreatureComponent>().GetComponent<ObjectWait>().Wait<Wait_KillAllCampB>();
            }
            
            MoveCastle.StartMove(self.DomainScene());
            
            self.SpawnCurEnemy();

        }
        
        



        
        
    }
    
}