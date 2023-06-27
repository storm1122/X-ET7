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
    public class BattleSceneEnter : AEvent<Scene, EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(Scene currentScene, SceneChangeFinish a)
        {
            if (currentScene.Name != ConstValue.BattleSceneName)
            {
                return;
            }

            var battle = currentScene.AddComponent<BattleComponent>();

            var battleData = currentScene.AddComponent<BattleData>();

            // 落脚点设置
            var footHoldComponent = currentScene.AddComponent<FootHoldComponent>();

            footHoldComponent.CurPathIdx = battleData.CurPathIdx;

            int idx = 0;
            foreach (var pos in battleData.Path)
            {
                int cfgId = 1;
                var footHold = footHoldComponent.AddChildWithId<FootHold, int>(idx, cfgId);
                footHold.Pos = pos;
                idx++;
            }

            // 创建城堡
            var creatureComponent = currentScene.AddComponent<CreatureComponent>();
            var c1 = creatureComponent.CreateCreature(1001, CreatureType.Castle);

            c1.Position = footHoldComponent.GetChild<FootHold>(0).Pos;

            var move = c1.AddComponent<MoveComponent>();

            move.MoveToAsync(battleData.Path, 10).Coroutine();

            EventSystem.Instance.Publish(currentScene, new Evt_SceneEnter());

            await ETTask.CompletedTask;
        }
    }
}