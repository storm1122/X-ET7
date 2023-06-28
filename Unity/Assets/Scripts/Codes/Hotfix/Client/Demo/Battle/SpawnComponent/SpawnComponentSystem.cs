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

            foreach (var creatureId in self.Config.CreatureIds)
            {
                CreatureConfig cfg = CreatureConfigCategory.Instance.GetOrDefault(creatureId);
                if (cfg == null)
                {
                    Log.Error($"CreatureConfig中找不到CreatureId：{creatureId}");
                    continue;
                }
                var creature = creatureComponent.CreateCreature(creatureId, cfg.Type);
                // todo 设置初始位置
                
                // todo 追踪组件

                
                
                await TimerComponent.Instance.WaitAsync(self.Config.Interval, self.CancelInterval);
                
                if (self.CancelInterval.IsCancel())
                {
                    return;
                }
            }
        }

    }
}