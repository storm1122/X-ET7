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


    //
    // [ObjectSystem]
    // [FriendOfAttribute(typeof(ET.Client.FootHoldComponent))]
    // [FriendOfAttribute(typeof(ET.MoveComponent))]
    // public class FootHoldUpdateSystem : UpdateSystem<FootHold>
    // {
    //     protected override void Update(FootHold self)
    //     {
    //         var footHoldComponent = self.Parent as FootHoldComponent;
    //         if (self.Idx != footHoldComponent.CurPathIdx)
    //         {
    //             return;
    //         }
    //
    //         var castle = self.DomainScene().GetComponent<CreatureComponent>().Castle;
    //
    //         if (TSVector.Distance(castle.Position, self.Pos) <= 0.2)
    //         {
    //             footHoldComponent.EnterNextFootHold();
    //         }
    //     }
    // }

    public static class FootHoldSystem
    {
    }
}