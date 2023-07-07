using TrueSync;

namespace ET.Client
{
    [ObjectSystem]
    public class Script_EnemyAtkAwakeSystem: AwakeSystem<Script_EnemyAtk, int>
    {
        protected override void Awake(Script_EnemyAtk self, int idx)
        {
            self.Idx = idx;
        }
    }

    [ObjectSystem]
    public class Script_EnemyAtkDestorySystem: DestroySystem<Script_EnemyAtk>
    {
        protected override void Destroy(Script_EnemyAtk self)
        {
        }
    }

    [ObjectSystem]
    [FriendOfAttribute(typeof(ET.Client.Creature))]
    [FriendOfAttribute(typeof(ET.Client.Damage))]
    public class Script_EnemyAtkSpellLaunchSystemSystem : SpellLaunchSystem<Script_EnemyAtk>
    {
        protected override void SpellLaunch(Script_EnemyAtk self)
        {
            Log.Console($"Script_EnemyAtk Launch:");
            var spell = self.GetParent<Spell>();

            var owner = spell.Owner;

            var arg = spell.GetArg(self.Idx);


            var target = CreatureHelper.GetRole(self.DomainScene());

            if (!target.Alive)
            {
                return;
            }


            // 检查参数
            var dmgPct = arg[0];
            var distance = arg[1];

            var _dis = owner.Distance(target);
            
            // if (_dis < FP.One)
            // {
            //     return;
            // }
            
            Log.Console($"Script_EnemyAtk owner:{owner.ConfigId} , {owner.Id} , atk:{arg[0]}");

            var dmg = spell.CreateDamage();
            dmg.DmgPct = dmgPct;
            
            target.TakeDamage(dmg);

            spell.OnSpellEnd();

        }
    }

    public static class Script_EnemyAtkSystem
    {
  

    }
}