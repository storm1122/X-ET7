using TrueSync;
using Unity.Mathematics;

namespace ET.Client
{
    [Invoke(TimerInvokeType.BattleSpawnTimer)]
    public class SpawnComponentTimeout: ATimer<SpawnComponent>
    {
        protected override void Run(SpawnComponent self)
        {
            self.Spawn().Coroutine();
        }
    }
    
    [ObjectSystem]
    public class SpawnComponentAwakeSystem: AwakeSystem<SpawnComponent, int>
    {
        protected override void Awake(SpawnComponent self, int configId)
        {
            self.ConfigId = configId;
            
            var cancelToken = new ETCancellationToken();
            self.CancelInterval = cancelToken;
        }
    }

    [ObjectSystem]
    public class SpawnComponentDestorySystem: DestroySystem<SpawnComponent>
    {
        protected override void Destroy(SpawnComponent self)
        {
            TimerComponent.Instance.Remove(ref self.Timer);
            self.CancelInterval?.Cancel();
            self.CancelInterval = null;
        }
    }

    [FriendOfAttribute(typeof(ET.Client.SpawnComponent))]
    [FriendOfAttribute(typeof(ET.Client.Creature))]
    public static class SpawnComponentSystem
    {
        public static void WaitSpawn(this SpawnComponent self)
        {
            var delay = self.Config.DelayTime;
            self.Timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ClientNow() + delay, TimerInvokeType.BattleSpawnTimer, self);
        }


      
        
        public static async ETTask Spawn(this SpawnComponent self)
        {
            var creatureComponent = self.DomainScene().GetComponent<CreatureComponent>();
            if (creatureComponent == null)
            {
                Log.Error($"CreatureComponent is null");
                return;
            }
            
            if (self.Config.CreatureIds.Count != self.Config.CreatureCount.Count)
            {
                Log.Error($"SpawnConfig中，数量配置不正确，Id：{self.ConfigId}");
                return;
            }

            var spawnPosComponent = self.DomainScene().GetComponent<SpawnPosComponent>();
            if (spawnPosComponent == null)
            {
                spawnPosComponent = self.DomainScene().AddComponent<SpawnPosComponent,int>(1);
            }
            var role = CreatureHelper.GetRole(self.DomainScene());
            
            
            
            for (int i = 0; i < self.Config.CreatureIds.Count; i++)
            {
                var creatureId = self.Config.CreatureIds[i];
                int spawnCount = self.Config.CreatureCount[i];

                CreatureConfig cfg = CreatureConfigCategory.Instance.GetOrDefault(creatureId);
                if (cfg == null)
                {
                    Log.Error($"CreatureConfig中找不到CreatureId：{creatureId}");
                    continue;
                }

                for (int j = 0; j < spawnCount; j++)
                {

                    if (role.IsDisposed)
                    {
                        return;
                    }
                    
                    var creature = self.DomainScene().GetComponent<CreatureComponent>().CreateCreature(creatureId, Camp.B);

                    // todo 设置初始位置
                    creature.Position = spawnPosComponent.Circle(role.Position, ConstValue.SpawnMinRadius, ConstValue.SpawnMaxRadius);
                    //
                    // var list = CreatureHelper.GetCreature(self.DomainScene(), Camp.B);
                    //
                    // creature.Position = new TSVector(-5, 0, list.Count * 2);

                    if (creature.CreatureType != CreatureType.Treasure)
                    {
                        creature.AddComponent<AIComponent, int>(1);
                    }

                    // todo 追踪组件
                }



                await TimerComponent.Instance.WaitAsync(self.Config.Interval, self.CancelInterval);

                if (self.CancelInterval.IsCancel())
                {
                    return;
                }
            }
        }

    }
}