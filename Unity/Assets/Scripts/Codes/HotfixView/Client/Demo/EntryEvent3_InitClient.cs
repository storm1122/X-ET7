using System;
using System.IO;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Process)]
    public class EntryEvent3_InitClient: AEvent<ET.EventType.EntryEvent3>
    {
        protected override async ETTask Run(Scene scene, ET.EventType.EntryEvent3 args)
        {
            // 加载配置
            
            Root.Instance.Scene.AddComponent<GlobalComponent>();
            
            Root.Instance.Scene.AddComponent<FsmDispatcherComponent>();

            Scene clientScene = await SceneFactory.CreateClientScene(1, "Game");

            FUIComponent fuiComponent = clientScene.GetComponent<FUIComponent>();

            // 热更流程
            await ResComponent.Instance.InitResourceAsync(clientScene);
            
            // 加载 Packages
            await FUIPackageLoader.LoadPackagesAsync(fuiComponent);

            LoginPanel_ContextData contextData = fuiComponent.AddChild<LoginPanel_ContextData>();
            contextData.Data = "界面参数测试";
            // 显示登录界面, 并传递参数contextData
            await clientScene.GetComponent<FUIComponent>().ShowPanelAsync(PanelId.LoginPanel, contextData);

            await EventSystem.Instance.PublishAsync(clientScene, new EventType.AppStartInitFinish());
        }
    }
}