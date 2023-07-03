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
        //守关者，杀光才能刷普通怪
        public static void SpawnGuide(this FootHold self)
        {
            if (self.Id >= self.LvConfig.SpawnGuide.Length)
            {
                return;
            }
            foreach (var cfgId in self.LvConfig.SpawnGuide[self.Id])
            {
                var spawnComponent =  self.AddChild<SpawnComponent, int>(cfgId);
                spawnComponent.Spawn().Coroutine();
            }
        }
        
        //刷普通怪
        public static void SpawnNormal(this FootHold self)
        {
            foreach (var cfgId in self.LvConfig.SpawnInfos[self.Id])
            {
                var spawnComponent =  self.AddChild<SpawnComponent, int>(cfgId);
                spawnComponent.WaitSpawn();
            }
        }

    }
}