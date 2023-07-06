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
    public class Script_EnemyAtkSpellAddSystem : SpellAddSystem<Script_EnemyAtk>
    {
        protected override void SpellAdd(Script_EnemyAtk self)
        {
            var owner = self.GetParent<Spell>().Owner;
            Log.Console($"owner:{owner.ConfigId} , {owner.Id}");
        }
    }

    public static class Script_EnemyAtkSystem
    {

    }
}