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
            
            await ETTask.CompletedTask;
        }
    }
}