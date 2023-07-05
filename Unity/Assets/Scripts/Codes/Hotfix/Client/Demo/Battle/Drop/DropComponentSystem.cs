
using TrueSync;

namespace ET.Client
{
    [ObjectSystem]
    public class DropComponentAwakeSystem: AwakeSystem<DropComponent>
    {
        protected override void Awake(DropComponent self)
        {
        }
    }

    [ObjectSystem]
    public class DropComponentDestorySystem: DestroySystem<DropComponent>
    {
        protected override void Destroy(DropComponent self)
        {
        }
    }

    public static class DropComponentSystem
    {
        public static void Create(this DropComponent self , int configId, TSVector pos)
        {
            var item = self.AddChild<Drop, int>(configId);

            item.SetPos(pos);
        }

    }
}