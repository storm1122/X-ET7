using ET.Client.BattleEvent;

namespace ET.Client
{
    [ObjectSystem]
    public class CreatureComponentAwakeSystem: AwakeSystem<CreatureComponent>
    {
        protected override void Awake(CreatureComponent self)
        {
            self.AddComponent<ObjectWait>();
        }
    }

    [ObjectSystem]
    public class CreatureComponentDestorySystem: DestroySystem<CreatureComponent>
    {
        protected override void Destroy(CreatureComponent self)
        {
        }
    }

    [ObjectSystem]
    public class CreatureComponentUpdateSystem: UpdateSystem<CreatureComponent>
    {
        protected override void Update(CreatureComponent self)
        {
            
        }
    }


    [FriendOfAttribute(typeof(ET.Client.Creature))]
    public static class CreatureComponentSystem
    {
        public static Creature CreateCreature(this CreatureComponent self, int configId, Camp camp)
        {
            var creature = self.AddChild<Creature, int>(configId);
            EventSystem.Instance.Publish(self.DomainScene(), new Evt_CreateCreature { Creature = creature });
            creature.Camp = camp;
            return creature;
        }

        public static void CreatureDead(this CreatureComponent self, Creature creature)
        {
            if (creature.CreatureType == CreatureType.Role)
            {
                EventSystem.Instance.Publish(self.DomainScene(), new Evt_BattleEnd { });
                return;
            }
            
            
            EventSystem.Instance.Publish(self.DomainScene(), new Evt_RemoveCreature { Creature = creature });
            creature.Dispose();

            var enemys = CreatureHelper.GetCreature(self.DomainScene(), Camp.B);
            if (enemys.Count <= 0)
            {
                self.GetComponent<ObjectWait>().Notify(new Wait_KillAllCampB());
            }
            
            

        }
        
    }
}

