using ET.Client.BattleEvent;

namespace ET.Client
{
    [ObjectSystem]
    public class CreatureComponentAwakeSystem: AwakeSystem<CreatureComponent>
    {
        protected override void Awake(CreatureComponent self)
        {
        }
    }

    [ObjectSystem]
    public class CreatureComponentDestorySystem: DestroySystem<CreatureComponent>
    {
        protected override void Destroy(CreatureComponent self)
        {
        }
    }
    [FriendOfAttribute(typeof(ET.Client.Creature))]
    public static class CreatureComponentSystem
    {
        public static Creature CreateCreature(this CreatureComponent self, int configId, CreatureType type)
        {
            var creature = self.AddChild<Creature, int>(configId);
            EventSystem.Instance.Publish(self.DomainScene(), new Evt_CreateCreature { Creature = creature });
            creature.CreatureType = type;
            return creature;
        }

    }
}

