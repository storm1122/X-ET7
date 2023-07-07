namespace ET.Client
{
    [ObjectSystem]
    public class SpellAwakeSystem: AwakeSystem<Spell, int>
    {
        protected override void Awake(Spell self, int configId)
        {
            self.ConfigId = configId;

            self.MaxCd = 2000;

            self.NextCd = TimeHelper.ClientNow();

            self.Cd = self.NextCd + 1;

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


    [FriendOfAttribute(typeof(ET.Client.Spell))]
    public static class SpellSystem
    {

        public static Damage CreateDamage(this Spell self)
        {
            var damageComponent = self.DomainScene().GetComponent<DamageComponent>();

            var dmg = damageComponent.AddChild<Damage>();

            dmg.Owner = self.Owner;

            return dmg;

        }

        public static void Cast(this Spell self)
        {
            if (self.NextCd - self.Cd > 0 )
            {
                self.Cd = TimeHelper.ClientNow();
             
                return;
            }

            
            // 目前不考虑前摇，直接发出技能
            self.OnLaunch();

        }

        public static void OnAdd(this Spell self, Creature owner)
        {
            self.Owner = owner;

            EventSystem.Instance.SpellAdd(self);

        }

        public static void OnRemove(this Spell self)
        {

            EventSystem.Instance.SpellRemove(self);
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
            self.ResetCD();
        }
        
        private static void OnInterval(this Spell self)
        {

        }

        private static void ResetCD(this Spell self)
        {
            self.NextCd = TimeHelper.ClientNow() + self.MaxCd;
        }

    }
}