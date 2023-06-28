namespace ET.Client
{
    [Invoke(TimerInvokeType.BattleSpawnTimer)]
    public class SpawnComponentTimeout: ATimer<SpawnComponent>
    {
        protected override void Run(SpawnComponent self)
        {
            self.Spawn();
        }
    }
    
    [ObjectSystem]
    public class SpawnComponentAwakeSystem: AwakeSystem<SpawnComponent, int>
    {
        protected override void Awake(SpawnComponent self, int configId)
        {
            self.ConfigId = configId;
            self.SpawnTime = 5000;

        }
    }

    [ObjectSystem]
    public class SpawnComponentDestorySystem: DestroySystem<SpawnComponent>
    {
        protected override void Destroy(SpawnComponent self)
        {
        }
    }
    
    [FriendOfAttribute(typeof(ET.Client.SpawnComponent))]
    public static class SpawnComponentSystem
    {
        public static void WaitSpawn(this SpawnComponent self)
        {
            self.Timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ClientNow() + self.SpawnTime, TimerInvokeType.BattleSpawnTimer, self);
        }

        public static void Spawn(this SpawnComponent self)
        {
            Log.Console("spawn !!! ");
        }

    }
}