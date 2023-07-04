using ET.Client.BattleEvent;
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

        public static void PickUp(this Drop self)
        {
            var idx = 0;
            foreach (var script in self.Config.DropConfigScript)
            {
                var arg = self.Config.Arg[idx];
                if (script == DropConfigScript.Exp)
                {
                    Log.Console("拾取金币");
                }
                else if (script == DropConfigScript.Power)
                {
                    Log.Console("拾取能量");
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