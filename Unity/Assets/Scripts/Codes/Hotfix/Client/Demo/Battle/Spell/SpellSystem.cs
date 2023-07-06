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

    public static class SpellSystem
    {

        public static void Cast(this Spell self)
        {
            
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
            
        }

        private static void OnInterval(this Spell self)
        {
            
        }

    }
}