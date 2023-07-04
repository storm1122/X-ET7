using Unity.Mathematics;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class BattleRandom : Entity, IAwake<int>
    {
        public Random Random;
    }
}