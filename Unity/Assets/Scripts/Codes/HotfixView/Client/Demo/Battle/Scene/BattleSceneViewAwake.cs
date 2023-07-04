using System.IO;
using ET.Client.BattleEvent;
using ET.EventType;
using UnityEngine;

namespace ET.Client
{

    [Event(SceneType.Current)]
    public class BattleSceneViewAwake : AEvent<Scene, Evt_SceneAwake>
    {
        protected override async ETTask Run(Scene currentScene, Evt_SceneAwake a)
        {
            currentScene.AddComponent<CreatureViewComponent>();
            currentScene.AddComponent<DropViewComponent>();
            currentScene.AddComponent<FootHoldViewComponent>();
            
            await ETTask.CompletedTask;
        }
    }
    
    [Event(SceneType.Current)]
    public class Evt_BattleEndHandler : AEvent<Scene, Evt_BattleEnd>
    {
        protected override async ETTask Run(Scene currentScene, Evt_BattleEnd a)
        {
            currentScene.GetComponent<FUIComponent>().ShowPanelAsync(PanelId.DemoEndPanel).Coroutine();
            
            await ETTask.CompletedTask;
        }
    }
    
    
    
}