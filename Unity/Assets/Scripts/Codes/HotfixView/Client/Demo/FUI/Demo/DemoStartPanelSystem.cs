using ET.Client.Demo;
using FairyGUI;

namespace ET.Client
{
    [FriendOf(typeof(DemoStartPanel))]
    [FriendOfAttribute(typeof(ET.Client.BattleData))]
    public static class DemoStartPanelSystem
    {
        public static void Awake(this DemoStartPanel self)
        {
            self.CfgList.Clear();

            foreach (var cfg in BattleLevelConfigCategory.Instance.GetAll())
            {
                self.CfgList.Add(cfg.Value);
            }
        }

        public static void RegisterUIEvent(this DemoStartPanel self)
        {
            self.FUIDemoStartPanel.LvList.itemRenderer = self.LvRenderer;
        }

        public static void OnShow(this DemoStartPanel self, Entity contextData = null)
        {
            self.FUIDemoStartPanel.LvList.numItems = self.CfgList.Count;
            self.FUIDemoStartPanel.LvList.onClickItem.Add(self.OnLvBtnClick);
            
            
        }

        public static void OnHide(this DemoStartPanel self)
        {
        }

        public static void BeforeUnload(this DemoStartPanel self)
        {
            self.CfgList.Clear();
        }

        private static void LvRenderer(this DemoStartPanel self, int index, GObject obj)
        {
            var item = obj as FUI_NormalBtn1;

            var cfg = self.CfgList[index];

            item.data = index;

            item.title = $"关卡ID:{cfg.Id}";
        }


        private static void OnLvBtnClick(this DemoStartPanel self, EventContext context)
        {
            FUI_NormalBtn1 item = (FUI_NormalBtn1)context.data;
            int index = (int)item.data;

            var cfg = self.CfgList[index];


            if (self.ClientScene().GetComponent<BattleData>() == null)
            {
                self.ClientScene().AddComponent<BattleData>();
            }

            Log.Console(self.FUIDemoStartPanel.Input.Input.text);
            
            self.ClientScene().GetComponent<BattleData>().BattleLevelConfigId = cfg.Id;

            if (!string.IsNullOrEmpty(self.FUIDemoStartPanel.Input.Input.text))
            {
                var startIdx = int.Parse(self.FUIDemoStartPanel.Input.Input.text);

                self.ClientScene().GetComponent<BattleData>().BattleLevelStartIdx = startIdx;


                Log.Console(
                    $"设置起始点，关卡id:{self.ClientScene().GetComponent<BattleData>().BattleLevelConfigId} , 起始idx:{self.ClientScene().GetComponent<BattleData>().BattleLevelStartIdx}");
            }
            
            self.EnterBattle();
        }



        private static void EnterBattle(this DemoStartPanel self)
        {
            var uid = IdGenerater.Instance.GenerateInstanceId();
            Client.SceneChangeHelper.SceneChangeTo(self.ClientScene(), ConstValue.BattleSceneName, uid).Coroutine();
        }
    }
}