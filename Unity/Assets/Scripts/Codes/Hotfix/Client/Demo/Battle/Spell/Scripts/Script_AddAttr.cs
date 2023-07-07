namespace ET.Client
{
    [ObjectSystem]
    public class Script_AddAttrAwakeSystem: AwakeSystem<Script_AddAttr, int>
    {
        protected override void Awake(Script_AddAttr self, int idx)
        {
            self.Idx = idx;
        }
    }

    [ObjectSystem]
    public class Script_AddAttrDestorySystem: DestroySystem<Script_AddAttr>
    {
        protected override void Destroy(Script_AddAttr self)
        {
        }
    }


    [ObjectSystem]
    [FriendOfAttribute(typeof(ET.Client.Creature))]
    [FriendOfAttribute(typeof(ET.Client.Spell))]
    public class Script_AddAttrSpellAddSystem : SpellAddSystem<Script_AddAttr>
    {
        protected override void SpellAdd(Script_AddAttr self)
        {
            var spell = self.GetParent<Spell>();

            var owner = spell.Owner;

            if (self.Idx >= spell.Config.AddAttrArg.Length)
            {
                Log.Error($"spell:{spell.ConfigId}, Script_AddAttr ERROR, AddAttrArg idx:{self.Idx}");
                return;
            }

            var arg = spell.Config.AddAttrArg[self.Idx];

            foreach (var data in arg)
            {
                owner.AddAttr(data.Key, data.Value);
            }
        }
    }

    [ObjectSystem]
    [FriendOfAttribute(typeof(ET.Client.Creature))]
    public class Script_AddAttrSpellRemoveSystem : SpellRemoveSystem<Script_AddAttr>
    {
        protected override void SpellRemove(Script_AddAttr self)
        {
            var spell = self.GetParent<Spell>();

            var owner = spell.Owner;

            var arg = spell.Config.AddAttrArg[self.Idx];

            foreach (var data in arg)
            {
                owner.AddAttr(data.Key, -data.Value);
            }
        }
    }


    public static class Script_AddAttrSystem
    {
       
    }
   
}