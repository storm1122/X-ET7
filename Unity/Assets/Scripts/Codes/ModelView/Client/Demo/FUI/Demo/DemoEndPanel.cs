using ET.Client.Demo;

namespace ET.Client
{
	[ComponentOf(typeof(FUIEntity))]
	public class DemoEndPanel: Entity, IAwake
	{
		private FUI_DemoEndPanel _fuiDemoEndPanel;

		public FUI_DemoEndPanel FUIDemoEndPanel
		{
			get => _fuiDemoEndPanel ??= (FUI_DemoEndPanel)this.GetParent<FUIEntity>().GComponent;
		}
	}
}
