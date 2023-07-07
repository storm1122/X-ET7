using System.Collections.Generic;

namespace ET.Client
{
    [FriendOfAttribute(typeof(ET.Client.Spell))]
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

        public static List<int> GetArg(this Spell self, int idx)
        {
            if (idx >= self.Config.Arg.Length)
            {
                Log.Error($"获取参数错误，spellId:{self.ConfigId}, idx:{idx}");
                return new List<int>();
            }
            List<int> args = self.Config.Arg[idx];
            return args;
        }
    }
}