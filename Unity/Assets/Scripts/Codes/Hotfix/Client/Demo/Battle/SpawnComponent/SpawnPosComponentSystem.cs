using TrueSync;
using Unity.Mathematics;

namespace ET.Client
{
    [ObjectSystem]
    public class SpawnPosComponenAwakeSystem: AwakeSystem<SpawnPosComponent, int>
    {
        protected override void Awake(SpawnPosComponent self, int seed)
        {
            self.Random = new Random(1);
        }
    }

    [ObjectSystem]
    public class SpawnPosComponentDestorySystem: DestroySystem<SpawnPosComponent>
    {
        protected override void Destroy(SpawnPosComponent self)
        {
        }
    }
    [FriendOfAttribute(typeof(ET.Client.SpawnPosComponent))]
    public static class SpawnPosComponentSystem
    {
        public static TSVector Circle(this SpawnPosComponent self, TSVector center, int minRadius , int maxRadius)
        {
            var centerX = center.x;
            var centerY = center.z;

            // 生成以圆心为中心、半径为radius的圆内的随机点坐标
            double angle = self.Random.NextDouble() * 2 * math.PI; // 随机生成一个角度（弧度制）
            double distance = minRadius + math.sqrt(self.Random.NextDouble()) * maxRadius; // 随机生成一个距离（在圆半径范围内）

            // 计算点的坐标
            int x = (int)(centerX + distance * math.cos(angle));
            int y = (int)(centerY + distance * math.sin(angle));

            return new TSVector(x, 0, y);
        }
    }
}