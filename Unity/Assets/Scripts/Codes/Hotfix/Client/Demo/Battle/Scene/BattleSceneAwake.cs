using System.Collections.Generic;
using System.IO;

using ET.EventType;
using TrueSync;

namespace ET.Client
{

    [Event(SceneType.Current)]
    [FriendOfAttribute(typeof(ET.Client.FootHold))]
    [FriendOfAttribute(typeof(ET.Client.Creature))]
    public class BattleSceneAwake : AEvent<Scene, EventType.AfterCreateCurrentScene>
    {
        protected override async ETTask Run(Scene currentScene, AfterCreateCurrentScene a)
        {
            if (currentScene.Name != ConstValue.BattleSceneName)
            {
                return;
            }
            
            EventSystem.Instance.Publish(currentScene, new Evt_SceneAwake());

            await ETTask.CompletedTask;
        }
    }
}