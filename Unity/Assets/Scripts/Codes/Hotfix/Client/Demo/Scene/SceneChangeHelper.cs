﻿namespace ET.Client
{
    public static class SceneChangeHelper
    {
        public static async ETTask SceneChangeTo(Scene clientScene, string sceneName, long sceneInstanceId)
        {
            var uid = IdGenerater.Instance.GenerateInstanceId();

            if (clientScene.GetComponent<BattleData>() == null)
            {
                clientScene.AddComponent<BattleData>();
            }
            
            CurrentScenesComponent currentScenesComponent = clientScene.GetComponent<CurrentScenesComponent>();
            currentScenesComponent.Scene?.Dispose(); // 删除之前的CurrentScene，创建新的
            Scene currentScene = SceneFactory.CreateCurrentScene(uid, clientScene.Zone, sceneName, currentScenesComponent);
         
#if !DOTNET
            
            // 可以订阅这个事件中创建Loading界面
            await EventSystem.Instance.PublishAsync(clientScene, new EventType.SceneChangeStart());
#endif
            // 等待CreateMyUnit的消息
            // Wait_CreateMyUnit waitCreateMyUnit = await clientScene.GetComponent<ObjectWait>().Wait<Wait_CreateMyUnit>();
            // M2C_CreateMyUnit m2CCreateMyUnit = waitCreateMyUnit.Message;
            // Unit unit = UnitFactory.Create(currentScene, m2CCreateMyUnit.Unit);
            
            EventSystem.Instance.Publish(currentScene, new EventType.SceneChangeFinish());
            // 通知等待场景切换的协程
            // clientScene.GetComponent<ObjectWait>().Notify(new Wait_SceneChangeFinish());

            await ETTask.CompletedTask;
        }
    }
}