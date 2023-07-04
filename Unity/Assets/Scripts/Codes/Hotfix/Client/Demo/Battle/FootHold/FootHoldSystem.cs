using ET.Client.BattleEvent;
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

            EventSystem.Instance.Publish(self.DomainScene(), new Evt_CreateFootHold { FootHold = self });

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