namespace ET.Client
{

    [ObjectSystem]
    public class FootHoldComponentAwakeSystem: AwakeSystem<FootHoldComponent>
    {
        protected override void Awake(FootHoldComponent self)
        {
        }
    }

    [ObjectSystem]
    public class FootHoldComponentDestorySystem: DestroySystem<FootHoldComponent>
    {
        protected override void Destroy(FootHoldComponent self)
        {
            self.CurPathIdx = 0;
        }
    }

    public static class FootHoldComponentSystem
    {
        
    }
}