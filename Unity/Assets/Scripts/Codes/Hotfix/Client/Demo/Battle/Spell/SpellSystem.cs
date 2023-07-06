namespace ET.Client
{
    [ObjectSystem]
    public class SpellAwakeSystem: AwakeSystem<Spell, int>
    {
        protected override void Awake(Spell self, int configId)
        {
            self.ConfigId = configId;

            if (configId == 1)
            {
                Log.Error("AddChild<Script_AddAttr>");
                self.AddChild<Script_AddAttr>();
            }
            else
            {
                Log.Error("AddChild<Script_Nromal1>");
                self.AddChild<Script_Nromal1>();
            }
        }
    }

    [ObjectSystem]
    public class SpellDestorySystem: DestroySystem<Spell>
    {
        protected override void Destroy(Spell self)
        {
        }
    }

    public static class SpellSystem
    {

        public static void Cast(this Spell self)
        {
            
        }
        
        public static void OnAdd(this Spell self, Creature owner)
        {
            self.Owner = owner;

            Log.Error("Spell.OnAdd");
            EventSystem.Instance.SpellAdd(self);
            EventSystem.Instance.Publish(self.DomainScene(), new Evt_Spell_OnAdd { Spell = self });

        }
        
        public static void OnRemove(this Spell self)
        {
            
            EventSystem.Instance.Publish(self.DomainScene(), new Evt_Spell_OnRemove { Spell = self });
        }

        private static void OnCast(this Spell self)
        {
            
        }
        
        private static void OnLaunch(this Spell self)
        {
            
        }

        private static void OnInterval(this Spell self)
        {
            
        }

    }
}