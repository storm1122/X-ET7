using System.Collections.Generic;
using ET.Client.Demo;
using FairyGUI;

namespace ET.Client
{
	[ComponentOf(typeof(FUIEntity))]
	public class DemoStartPanel: Entity, IAwake
	{
		private FUI_DemoStartPanel _fuiDemoStartPanel;

		public FUI_DemoStartPanel FUIDemoStartPanel
		{
			get => _fuiDemoStartPanel ??= (FUI_DemoStartPanel)this.GetParent<FUIEntity>().GComponent;
		}

		public List<BattleLevelConfig> CfgList = new List<BattleLevelConfig>();

	}
}
