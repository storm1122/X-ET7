

namespace ET.Client
{
    
    [Event(SceneType.Current)]
    public class Evt_CreateFootHoldHandler : AEvent<Scene, Evt_CreateFootHold>
    {
        protected override async ETTask Run(Scene currentScene, Evt_CreateFootHold a)
        {
            var viewComponent = currentScene.GetComponent<FootHoldViewComponent>();
            var view = viewComponent.AddChildWithId<FootHoldView>(a.FootHold.Id);

            view.OnCreate(a.FootHold);
            
            await ETTask.CompletedTask;
        }
    }
    
}