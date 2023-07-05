using System.IO;
using ET.EventType;

namespace ET.Client
{

    [Event(SceneType.Current)]
    public class BattleSceneViewEnter : AEvent<Scene, Evt_SceneEnter>
    {
        protected override async ETTask Run(Scene currentScene, Evt_SceneEnter a)
        {
            currentScene.GetComponent<FUIComponent>().ShowPanelAsync(PanelId.DemoBattleInfo).Coroutine();  
            
            await ETTask.CompletedTask;
        }
    }
}