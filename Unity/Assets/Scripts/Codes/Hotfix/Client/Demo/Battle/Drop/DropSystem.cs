
using TrueSync;

namespace ET.Client
{
    [ObjectSystem]
    public class DropAwakeSystem: AwakeSystem<Drop, int>
    {
        protected override void Awake(Drop self, int configId)
        {
            self.ConfigId = configId;
        }
    }

    [ObjectSystem]
    public class DropDestorySystem: DestroySystem<Drop>
    {
        protected override void Destroy(Drop self)
        {
        }
    }

    [ObjectSystem]
    public class DropUpdateSystem: UpdateSystem<Drop>
    {
        protected override void Update(Drop self)
        {
            var role = CreatureHelper.GetRole(self.DomainScene());
            if (TSVector.Distance(role.Position, self.Position) < ConstValue.DropRange)
            {
                self.PickUp();
            }
        }
    }

    public static class DropSystem
    {
        public static void SetPos(this Drop self, TSVector pos)
        {
            self.Position = pos;
            EventSystem.Instance.Publish(self.DomainScene(), new Evt_CreateDrop { Drop = self });
        }

        
        //todo 这里存在环形依赖
        public static void PickUp(this Drop self)
        {
            var idx = 0;
            foreach (var script in self.Config.DropConfigScript)
            {
                var arg = self.Config.Arg[idx];
                if (script == DropConfigScript.Exp)
                {
                    var role = CreatureHelper.GetRole(self.DomainScene());
                    role.GetAttr()[AttrType.Exp] += arg[0];
                    Log.Console($"经验:{role.GetAttr()[AttrType.Exp]}");
                }
                else if (script == DropConfigScript.Power)
                {
                    var role = CreatureHelper.GetRole(self.DomainScene());
                    role.GetAttr()[AttrType.Power] += arg[0];
                    Log.Console($"能量:{role.GetAttr()[AttrType.Power]}");
                }
                idx++;
            }

            self.Remove();
        }

        public static void Remove(this Drop self)
        {
            EventSystem.Instance.Publish(self.DomainScene(), new Evt_RmoveDrop { Drop = self });
            self.Dispose();
        }
    }
}