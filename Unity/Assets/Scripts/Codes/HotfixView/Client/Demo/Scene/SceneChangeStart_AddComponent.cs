using UnityEngine.SceneManagement;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class SceneChangeStart_AddComponent: AEvent<Scene, EventType.SceneChangeStart>
    {
        protected override async ETTask Run(Scene scene, EventType.SceneChangeStart args)
        {
            Scene currentScene = scene.CurrentScene();

            ResComponent.Instance.UnloadUnusedAssets();
            
            await ResComponent.Instance.LoadSceneAsync(currentScene.Name);
        }
    }
}