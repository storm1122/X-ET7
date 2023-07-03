using ET.Client.Demo;

namespace ET.Client
{
	[ComponentOf(typeof(FUIEntity))]
	public class DemoBattleInfo: Entity, IAwake
	{
		private FUI_DemoBattleInfo _fuiDemoBattleInfo;

		public FUI_DemoBattleInfo FUIDemoBattleInfo
		{
			get => _fuiDemoBattleInfo ??= (FUI_DemoBattleInfo)this.GetParent<FUIEntity>().GComponent;
		}
	}
}
