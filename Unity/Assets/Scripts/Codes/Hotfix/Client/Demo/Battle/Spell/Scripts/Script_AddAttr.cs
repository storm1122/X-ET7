namespace ET.Client
{
    [Event(SceneType.Current)]
    public class Evt_Spell_OnAdd_Script_AddAttr: AEvent<Scene, Evt_Spell_OnAdd>
    {
        protected override async ETTask Run(Scene scene, Evt_Spell_OnAdd a)
        {
            var spell = a.Spell;


            await ETTask.CompletedTask;
        }
    }
    
    [Event(SceneType.Current)]
    public class Evt_Spell_OnRemove_Script_AddAttr: AEvent<Scene, Evt_Spell_OnRemove>
    {
        protected override async ETTask Run(Scene scene, Evt_Spell_OnRemove a)
        {
            var spell = a.Spell;


            await ETTask.CompletedTask;
        }
    }


    [ObjectSystem]
    public class SpellCompaaonentDestorySystem: SpellAddSystem<Script_AddAttr>
    {
        protected override void SpellAdd(Script_AddAttr self)
        {
            Log.Error(" Script_AddAttr Add !!!!");
        }
    }
    
    
    [ObjectSystem]
    public class SpellCompaaonentDestor1ySystem: SpellAddSystem<Script_Nromal1>
    {
        protected override void SpellAdd(Script_Nromal1 self)
        {
            Log.Error(" Script_Nromal1 Add !!!!");
        }
    }
}