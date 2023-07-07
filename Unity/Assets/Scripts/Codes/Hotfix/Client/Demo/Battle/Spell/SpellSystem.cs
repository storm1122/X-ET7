namespace ET.Client
{
    [ObjectSystem]
    public class SpellAwakeSystem: AwakeSystem<Spell, int>
    {
        protected override void Awake(Spell self, int configId)
        {
            self.ConfigId = configId;

            self.AddScriptByConfig();
        }
    }

    [ObjectSystem]
    public class SpellDestorySystem: DestroySystem<Spell>
    {
        protected override void Destroy(Spell self)
        {
        }
    }
    
    [ObjectSystem]
    public class SpellUpdateSystem: UpdateSystem<Spell>
    {
        protected override void Update(Spell self)
        {
            self.Cast();
        }
    }

    public static class SpellSystem
    {

        public static void Cast(this Spell self)
        {
            self.OnLaunch();
        }
        
        public static void OnAdd(this Spell self, Creature owner)
        {
            self.Owner = owner;

            EventSystem.Instance.SpellAdd(self);

        }
        
        public static void OnRemove(this Spell self)
        {
            
        }

        private static void OnCast(this Spell self)
        {
            
        }
        
        private static void OnLaunch(this Spell self)
        {
            EventSystem.Instance.SpellLaunch(self);
        }

        public static void OnSpellEnd(this Spell self)
        {
            
        }

        public static Damage CreateDamage(this Spell self)
        {
            var damageComponent = self.DomainScene().GetComponent<DamageComponent>();

            var dmg = damageComponent.AddChild<Damage>();

            dmg.Owner = self.Owner;

            return dmg;
        }
        
        private static void OnInterval(this Spell self)
        {
            
        }

    }
}