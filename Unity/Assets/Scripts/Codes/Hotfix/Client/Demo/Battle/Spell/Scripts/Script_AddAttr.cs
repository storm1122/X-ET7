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
    public class Script_AddAttrSpellAddSystem : SpellAddSystem<Script_AddAttr>
    {
        protected override void SpellAdd(Script_AddAttr self)
        {
            var spell = self.GetParent<Spell>();

            var owner = spell.Owner;

            var arg = spell.Config.AddAttrArg[self.Idx];

            foreach (var data in arg)
            {
                
                Log.Console($" Script_AddAttr 111  owner:{owner.ConfigId} , {owner.Id} , attr:Atk = {owner.GetAttrComponent().GetAsLong(AttrType.Atk)}");
                owner.AddAttr(data.Key, data.Value);
                Log.Console($" Script_AddAttr 222  owner:{owner.ConfigId} , {owner.Id} , attr:Atk = {owner.GetAttrComponent().GetAsLong(AttrType.Atk)}");
            }
        }
    }



    public static class Script_AddAttrSystem
    {
       
    }
   
}