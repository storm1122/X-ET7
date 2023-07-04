using ET.Client.BattleEvent;

namespace ET.Client
{
 
    [Event(SceneType.Current)]
    [FriendOfAttribute(typeof(ET.Client.CreatureView))]
    public class Evt_CreateCreatureHandler : AEvent<Scene, Evt_CreateCreature>
    {
        protected override async ETTask Run(Scene currentScene, Evt_CreateCreature a)
        {
            CreatureViewHelper.Create(currentScene, a);
            
            await ETTask.CompletedTask;
        }
    }


    [Event(SceneType.Current)]
    [FriendOfAttribute(typeof (ET.Client.CreatureView))]
    public class Evt_RemoveCreatureHandler: AEvent<Scene, Evt_RemoveCreature>
    {
        protected override async ETTask Run(Scene currentScene, Evt_RemoveCreature a)
        {
            var view = CreatureViewHelper.GetView(currentScene, a.Creature.Id);
            if (view == null)
            {
                return;
            }

            view.OnRemove(a.Creature);
                    
      
            
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Current)]
    [FriendOfAttribute(typeof(ET.Client.CreatureView))]
    public class Evt_ChangePosHandler : AEvent<Scene, Evt_ChangePos>
    {
        protected override async ETTask Run(Scene currentScene, Evt_ChangePos a)
        {
            
            var view = CreatureViewHelper.GetView(currentScene, a.Creature.Id); 
            if (view == null)
            {
                return;
            }
            view.OnChangePos(a.Creature);
            await ETTask.CompletedTask;
        }
    }
    
    [Event(SceneType.Current)]
    [FriendOfAttribute(typeof(ET.Client.CreatureView))]
    public class Evt_ChangeRotationHandler : AEvent<Scene, Evt_ChangeRotation>
    {
        protected override async ETTask Run(Scene currentScene, Evt_ChangeRotation a)
        {
            
            var view = CreatureViewHelper.GetView(currentScene, a.Creature.Id); 
            if (view == null)
            {
                return;
            }
            view.OnChangeRotation(a.Creature);
            
          
            await ETTask.CompletedTask;
        }
    }
}