/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Demo
{
	public partial class FUI_NormalInputField1: GComponent
	{
		public GTextInput Input;
		public GTextField simpleText;
		public GRichTextField richText;
		public const string URL = "ui://2k63u5d6i0nf47";

		public static FUI_NormalInputField1 CreateInstance()
		{
			return (FUI_NormalInputField1)UIPackage.CreateObject("Demo", "NormalInputField1");
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			Input = (GTextInput)GetChildAt(1);
			simpleText = (GTextField)GetChildAt(2);
			richText = (GRichTextField)GetChildAt(3);
		}
	}
}
