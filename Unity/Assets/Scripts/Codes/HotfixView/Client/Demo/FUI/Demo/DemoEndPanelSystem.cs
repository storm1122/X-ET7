namespace ET.Client
{
	[FriendOf(typeof(DemoEndPanel))]
	public static class DemoEndPanelSystem
	{
		public static void Awake(this DemoEndPanel self)
		{
		}

		public static void RegisterUIEvent(this DemoEndPanel self)
		{
			self.FUIDemoEndPanel.BtnBack.onClick.Add(() =>
			{
				self.DomainScene().GetComponent<FUIComponent>().HidePanel(PanelId.DemoEndPanel);

				self.ClientScene().GetComponent<FUIComponent>().ShowPanelAsync(PanelId.DemoStartPanel).Coroutine();
			});
		}

		public static void OnShow(this DemoEndPanel self, Entity contextData = null)
		{
		}

		public static void OnHide(this DemoEndPanel self)
		{
		}

		public static void BeforeUnload(this DemoEndPanel self)
		{
		}
	}
}