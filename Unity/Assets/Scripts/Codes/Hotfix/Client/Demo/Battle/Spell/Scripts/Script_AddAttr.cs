namespace ET.Client
{
    [ObjectSystem]
    public class Script_AddAttrAwakeSystem: AwakeSystem<Script_AddAttr, int>
    {
        protected override void Awake(Script_AddAttr self, int idx)
        {
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
    public class SpellCompaaonentDestorySystem: SpellAddSystem<Script_AddAttr>
    {
        protected override void SpellAdd(Script_AddAttr self)
        {
            Log.Console("vvvv");
            var spell = self.GetParent<Spell>();
        }
    }
    
    
    [ObjectSystem]
    public class SpellCompaaonentDestor1ySystem: SpellAddSystem<Script_NormalBullet>
    {
        protected override void SpellAdd(Script_NormalBullet self)
        {
            var spell = self.GetParent<Spell>();
            
            Log.Console("aaa");
        }
    }

    public static class Script_AddAttrSystem
    {
       
    }
   
}