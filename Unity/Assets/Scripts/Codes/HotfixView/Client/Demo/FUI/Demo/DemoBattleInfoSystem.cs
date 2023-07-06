

namespace ET.Client
{ 
	[Event(SceneType.Current)]
	public class UICreatureTakeDamageHandler : AEvent<Scene, Evt_CreatureTakeDamage>
	{
		protected override async ETTask Run(Scene currentScene, Evt_CreatureTakeDamage a)
		{
			DemoBattleInfo logic = currentScene.GetComponent<FUIComponent>().GetPanelLogic<DemoBattleInfo>();

			logic.HandleEvt_CreatureTakeDamage(a);
            
			await ETTask.CompletedTask;
		}
	}
	
	
	[FriendOf(typeof(DemoBattleInfo))]
	public static class DemoBattleInfoSystem
	{
		public static void Awake(this DemoBattleInfo self)
		{
		}

		public static void RegisterUIEvent(this DemoBattleInfo self)
		{
			self.FUIDemoBattleInfo.BtnExit.onClick.Add(()=>
			{
				Client.SceneChangeHelper.SceneChangeTo(self.ClientScene(), ConstValue.LobbySceneName, 888).Coroutine();
			});
		}

		public static void OnShow(this DemoBattleInfo self, Entity contextData = null)
		{
			var role = CreatureHelper.GetRole(self.DomainScene());
			var max = role.GetAttrComponent().GetAsLong(AttrType.MaxHp);
			self.FUIDemoBattleInfo.ProgressBar.max = max;
			self.FUIDemoBattleInfo.ProgressBar.min = 0;
			self.SetHpBar();
		}

		public static void SetHpBar(this DemoBattleInfo self)
		{
			var role = CreatureHelper.GetRole(self.DomainScene());

			var max = role.GetAttrComponent().GetAsLong(AttrType.MaxHp);
			var cur = role.GetAttrComponent().GetAsLong(AttrType.Hp);


			self.FUIDemoBattleInfo.ProgressBar.value = cur;
			// self.FUIDemoBattleInfo.ProgressBar.title.text = $"{cur}/{max}";
		}

		public static void OnHide(this DemoBattleInfo self)
		{
		}

		public static void BeforeUnload(this DemoBattleInfo self)
		{
		}

		public static void HandleEvt_CreatureTakeDamage(this DemoBattleInfo self, Evt_CreatureTakeDamage a)
		{
			if (a.Creature.InstanceId != CreatureHelper.GetRole(self.DomainScene()).InstanceId)
			{
				return;
			}
			self.SetHpBar();
			
		}
	}
}