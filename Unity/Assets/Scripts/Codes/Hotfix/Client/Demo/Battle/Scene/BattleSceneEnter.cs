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

            // 设置关卡
            var footHoldComponent = currentScene.AddComponent<FootHoldComponent, int>(ConstValue.BattleLevelConfigId);

            footHoldComponent.CurPathIdx = 0;
       
            // 创建城堡
            var creatureComponent = currentScene.AddComponent<CreatureComponent>();
            var c1 = creatureComponent.CreateCreature(1001, CreatureType.Castle);
            c1.Position = footHoldComponent.GetChild<FootHold>(0).Pos;
            // 城堡移动
            var move = c1.GetComponent<MoveComponent>();
            move.MoveToAsync(battleData.Path, c1.GetComponent<AttrComponent>().GetAsLong(AttrType.MoveSpeed)).Coroutine();
            
            footHoldComponent.Active();

            EventSystem.Instance.Publish(currentScene, new Evt_SceneEnter());

            await ETTask.CompletedTask;
        }
    }
}