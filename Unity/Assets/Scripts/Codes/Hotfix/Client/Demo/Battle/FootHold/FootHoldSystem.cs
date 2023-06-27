using TrueSync;

namespace ET.Client
{

    [ObjectSystem]
    public class FootHoldAwakeSystem: AwakeSystem<FootHold, int>
    {
        protected override void Awake(FootHold self, int configId)
        {
            self.ConfigId = configId;
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