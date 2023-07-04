using Unity.Mathematics;

namespace ET.Client
{

    [ObjectSystem]
    public class BattleRandomAwakeSystem: AwakeSystem<BattleRandom, int>
    {
        protected override void Awake(BattleRandom self, int seed)
        {
            self.Random = new Random(1);
        }
    }
    [FriendOfAttribute(typeof(ET.Client.BattleRandom))]

    public static class BattleRandomSystem
    {
        public static int Random10000(this BattleRandom self)
        {
            //NextInt Returns a uniformly random int value in the interval [0, max)
            return self.Random.NextInt(10000);
        }
    }
}