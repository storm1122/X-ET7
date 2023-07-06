namespace ET.Client
{
    public static class AddScriptChildHelper
    {
        public static void AddScriptByConfig(this Spell self)
        {
            int idx = 0;
            
            foreach (var spellKey in self.Config.Spellkey)
            {
                if (spellKey == SpellKey.AddAttr)
                {
                    self.AddChild<Script_AddAttr, int>(idx);
                }
                else if (spellKey == SpellKey.EnemyAtk)
                {
                    self.AddChild<Script_EnemyAtk, int>(idx);
                }
                else if (spellKey == SpellKey.NormalBullet)
                {
                    self.AddChild<Script_NormalBullet, int>(idx);
                }

                idx++;
            }
        }
    }
}