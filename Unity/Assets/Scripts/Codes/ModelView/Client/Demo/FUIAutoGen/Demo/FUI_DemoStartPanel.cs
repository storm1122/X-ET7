/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Demo
{
	public partial class FUI_DemoStartPanel: GComponent
	{
		public GList LvList;
		public ET.Client.Demo.FUI_NormalInputField1 Input;
		public const string URL = "ui://2k63u5d6i0nf0";

		public static FUI_DemoStartPanel CreateInstance()
		{
			return (FUI_DemoStartPanel)UIPackage.CreateObject("Demo", "DemoStartPanel");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			LvList = (GList)GetChildAt(0);
			Input = (ET.Client.Demo.FUI_NormalInputField1)GetChildAt(1);
		}
	}
}
