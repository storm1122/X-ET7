namespace ET.Client
{
    [Event(SceneType.Current)]
    public class AfterCreateCurrentScene_AddComponent: AEvent<Scene, EventType.AfterCreateCurrentScene>
    {
        protected override async ETTask Run(Scene scene, EventType.AfterCreateCurrentScene args)
        {
            var fuiComponent = scene.AddComponent<FUIComponent>();

            //暂时先写在这里了
            if (scene.Name == ConstValue.LobbySceneName)
            {
                fuiComponent.ShowPanelAsync(PanelId.DemoStartPanel).Coroutine();
            }
            
            await ETTask.CompletedTask;
        }
    }
}