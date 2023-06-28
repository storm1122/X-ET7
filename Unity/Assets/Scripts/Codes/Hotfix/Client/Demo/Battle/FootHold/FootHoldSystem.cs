using TrueSync;

namespace ET.Client
{

    [ObjectSystem]
    public class FootHoldAwakeSystem: AwakeSystem<FootHold, int>
    {
        protected override void Awake(FootHold self, int configId)
        {
            self.ConfigId = configId;

            foreach (var cfgId in self.Config.SpawnIds)
            {
                self.AddChild<SpawnComponent, int>(cfgId);
            }
        }
    }

    [ObjectSystem]
    public class FootHoldDestorySystem: DestroySystem<FootHold>
    {
        protected override void Destroy(FootHold self)
        {
            self.Pos = TSVector.zero;
        }
    }

    public static class FootHoldSystem
    {
    }
}