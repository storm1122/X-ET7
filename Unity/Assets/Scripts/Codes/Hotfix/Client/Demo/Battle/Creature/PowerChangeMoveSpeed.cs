
using ET.Client;
using TrueSync;

namespace ET.Client
{
    [AttrWatcher(SceneType.Current, AttrType.Power)]
    [FriendOfAttribute(typeof(ET.Client.Creature))]
    [FriendOfAttribute(typeof(ET.MoveComponent))]
    public class NumericWatcher_Hp_ShowUI2 : IAttrWatcher
    {
        public void Run(Creature creature, AttrChange args)
        {
            if (creature.CreatureType == CreatureType.Role)
            {
                var castle = CreatureHelper.GetCastle(creature.DomainScene());

                var move = castle.GetComponent<MoveComponent>();

                if (move != null)
                {
                    var speed = castle.GetCastleSpeed();

                    if (move.Speed - speed > 1)
                    {
                        move.ChangeSpeed(speed);
                    }
                }
            }
        }
    }
    [FriendOfAttribute(typeof(ET.Client.Creature))]
    public static class PowerChangeMoveSpeed
    {
        public static long GetCastleSpeed(this Creature self)
        {

            var rolePower = CreatureHelper.GetRole(self.DomainScene()).GetAttr().GetAsLong(AttrType.Power);
            var powerAdd = 0;
            if (self.Config.PowerSpeed.Count == self.Config.PowerSpeedVal.Count)
            {
                for (int j = 0; j < self.Config.PowerSpeed.Count; j++)
                {
                    var power = self.Config.PowerSpeed[j];
                    if (rolePower > power)
                    {
                        powerAdd = self.Config.PowerSpeedVal[j];
                    }
                }
            }
            else
            {
                Log.Error($"城堡的能量移速加成配置不正确，城堡ID：{self.ConfigId}");
            }

            var moveSpeed = self.GetAttr().GetAsLong(AttrType.MoveSpeed) + powerAdd;

            return moveSpeed;
        }
    }
}