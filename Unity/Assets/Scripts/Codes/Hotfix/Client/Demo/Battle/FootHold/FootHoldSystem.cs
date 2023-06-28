using TrueSync;

namespace ET.Client
{

    [ObjectSystem]
    public class FootHoldAwakeSystem: AwakeSystem<FootHold, int>
    {
        protected override void Awake(FootHold self, int idx)
        {
            self.Idx = idx;
            
            // 位置
            var x = self.LvConfig.PosXList[self.Id];
            var y = self.LvConfig.PosYList[self.Id];
            var z = self.LvConfig.PosZList[self.Id];
            self.Pos = new TSVector(x, y, z);
            
            // 刷怪
            foreach (var cfgId in self.LvConfig.SpawnInfos[self.Id])
            {
                self.AddChild<SpawnComponent, int>(cfgId);
            }
            
            // TODO 属性强化
            
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