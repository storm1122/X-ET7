/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Demo
{
	public partial class FUI_DemoEndPanel: GComponent
	{
		public ET.Client.Demo.FUI_NormalBtn1 BtnBack;
		public const string URL = "ui://2k63u5d6i0nf49";

		public static FUI_DemoEndPanel CreateInstance()
		{
			return (FUI_DemoEndPanel)UIPackage.CreateObject("Demo", "DemoEndPanel");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			BtnBack = (ET.Client.Demo.FUI_NormalBtn1)GetChildAt(0);
		}
	}
}
