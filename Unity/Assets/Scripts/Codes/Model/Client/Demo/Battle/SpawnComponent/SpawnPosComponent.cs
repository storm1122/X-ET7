using Unity.Mathematics;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class SpawnPosComponent : Entity, IAwake<int>, IDestroy
    {
        //后面要改成固定
        public Random Random;
    }
}