/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Demo
{
	public partial class FUI_ProgressBar1: GProgressBar
	{
		public GTextField title;
		public const string URL = "ui://2k63u5d6i0nf4b";

		public static FUI_ProgressBar1 CreateInstance()
		{
			return (FUI_ProgressBar1)UIPackage.CreateObject("Demo", "ProgressBar1");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			title = (GTextField)GetChildAt(2);
		}
	}
}
