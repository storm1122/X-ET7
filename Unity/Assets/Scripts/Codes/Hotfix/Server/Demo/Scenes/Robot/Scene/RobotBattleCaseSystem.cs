using System.Collections.Generic;

namespace ET.Server
{
    public static class RobotBattleCaseSystem
    {
        public static async ETTask Battle(this RobotCase self, List<Scene> scenes)
        {
            int zone = self.GetParent<RobotCaseComponent>().GetN();
            
            Scene clientScene = null;
            
            Log.Console("Enter Battle Case !!! ");
            
            clientScene = await Client.SceneFactory.CreateClientScene(zone, $"Robot_{zone}");

            var cfg = StartSceneConfigCategory.Instance.Get(7);

            await Client.SceneChangeHelper.SceneChangeTo(clientScene, cfg.Name, clientScene.Id + 1);
            
            self.Scenes.Add(clientScene.Id);
            
            scenes.Add(clientScene);
        }
    }
}