using ET.Client.BattleEvent;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class Evt_CreateDropHandler : AEvent<Scene, Evt_CreateDrop>
    {
        protected override async ETTask Run(Scene currentScene, Evt_CreateDrop a)
        {
            var viewComponent = currentScene.GetComponent<DropViewComponent>();
            var view = viewComponent.AddChildWithId<DropView>(a.Drop.Id);

            view.OnCreate(a.Drop);
            
            await ETTask.CompletedTask;
        }
    }
    
    [Event(SceneType.Current)]
    public class Evt_RmoveDropHandler : AEvent<Scene, Evt_RmoveDrop>
    {
        protected override async ETTask Run(Scene currentScene, Evt_RmoveDrop a)
        {
            var viewComponent = currentScene.GetComponent<DropViewComponent>();

            var view = viewComponent.GetChild<DropView>(a.Drop.Id);

            if (view != null)
            {
                view.OnRemove();
            }
            
            await ETTask.CompletedTask;
        }
    }
}