/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Demo
{
	public partial class FUI_DemoBattleInfo: GComponent
	{
		public ET.Client.Demo.FUI_ProgressBar1 ProgressBar;
		public ET.Client.Demo.FUI_NormalBtn1 BtnExit;
		public const string URL = "ui://2k63u5d6i0nf4a";

		public static FUI_DemoBattleInfo CreateInstance()
		{
			return (FUI_DemoBattleInfo)UIPackage.CreateObject("Demo", "DemoBattleInfo");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			ProgressBar = (ET.Client.Demo.FUI_ProgressBar1)GetChildAt(0);
			BtnExit = (ET.Client.Demo.FUI_NormalBtn1)GetChildAt(1);
		}
	}
}
