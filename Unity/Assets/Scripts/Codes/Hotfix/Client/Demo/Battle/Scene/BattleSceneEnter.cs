using System.IO;
using ET.Client.BattleEvent;
using ET.EventType;

namespace ET.Client
{

    [Event(SceneType.Current)]
    [FriendOfAttribute(typeof(ET.Client.BattleData))]
    [FriendOfAttribute(typeof(ET.Client.FootHold))]
    [FriendOfAttribute(typeof(ET.Client.Creature))]
    [FriendOfAttribute(typeof(ET.Client.FootHoldComponent))]
    [FriendOfAttribute(typeof(ET.Client.BattleComponent))]
    public class BattleSceneEnter : AEvent<Scene, EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(Scene currentScene, SceneChangeFinish a)
        {
            if (currentScene.Name != ConstValue.BattleSceneName)
            {
                return;
            }

            var battle = currentScene.AddComponent<BattleComponent>();

            battle.BattleAwake();


            battle.BattleStart();
            
            EventSystem.Instance.Publish(currentScene, new Evt_SceneEnter());

            
            await ETTask.CompletedTask;
        }
    }
}