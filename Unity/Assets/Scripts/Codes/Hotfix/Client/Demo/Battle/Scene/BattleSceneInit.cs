using System.IO;
using ET.EventType;

namespace ET.Client
{

    [Event(SceneType.Current)]
    [FriendOfAttribute(typeof(ET.Client.BattleData))]
    public class BattleSceneInit : AEvent<Scene, EventType.AfterCreateCurrentScene>
    {
        protected override async ETTask Run(Scene currentScene, AfterCreateCurrentScene a)
        {
            if (currentScene.Name != ConstValue.BattleSceneName)
            {
                return;
            }

            var battleData = currentScene.AddComponent<BattleData>();

            var footHoldComponent = currentScene.AddComponent<FootHoldComponent>();

            int idx = 0;
            foreach (var path in battleData.Path)
            {
                footHoldComponent.AddChildWithId<FootHold, int>(idx, 1);
                idx++;

            }

            var item = footHoldComponent.GetChild<FootHold>(0);
            
            Log.Console(item.Id.ToString());



            await ETTask.CompletedTask;
        }
    }
}