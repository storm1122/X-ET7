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

            if (!self.CheckConfig())
            {
                return;
            }

            self.CurPathIdx = 0;

            var footHoldIds = self.Config.FootHoldIds;
            
            for (int i = 0; i < footHoldIds.Length; i++)
            {
                // 创建
                var footHoldConfigId = footHoldIds[i];
                var footHold = self.AddChildWithId<FootHold, int>(i, footHoldConfigId);
                // 位置
                var x = self.Config.PosXList[i];
                var y = self.Config.PosYList[i];
                var z = self.Config.PosZList[i];
                footHold.Pos = new TSVector(x, y, z);
                // TODO 属性强化
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
        public static bool CheckConfig(this FootHoldComponent self)
        {
            var count = self.Config.FootHoldIds.Length;
            if (count != self.Config.PosXList.Length || count != self.Config.PosYList.Length || count != self.Config.PosZList.Length)
            {
                Log.Error($"BattleLevelConfig中数量不正确，configId：{self.ConfigId}");
                return false;
            }

            return true;
        }

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