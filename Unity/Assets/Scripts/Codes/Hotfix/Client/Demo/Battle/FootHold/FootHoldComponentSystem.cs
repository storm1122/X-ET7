using TrueSync;

namespace ET.Client
{

    [ObjectSystem]
    [FriendOfAttribute(typeof(ET.Client.FootHold))]
    public class FootHoldComponentAwakeSystem : AwakeSystem<FootHoldComponent, int>
    {
        protected override void Awake(FootHoldComponent self, int configId)
        {
            self.ConfigId = configId;

            self.CurPathIdx = 0;

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
            self.CurPathIdx = 0;
        }
    }
    [FriendOfAttribute(typeof(ET.Client.FootHoldComponent))]
    public static class FootHoldComponentSystem
    {

        public static void Active(this FootHoldComponent self)
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
        
    }
    
}