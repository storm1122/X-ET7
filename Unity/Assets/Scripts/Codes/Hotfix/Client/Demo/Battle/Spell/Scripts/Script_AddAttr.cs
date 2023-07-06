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
}