using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ET;
using UnityEngine;

namespace FUIEditor
{
    public static class FUIPanelSystemSpawner
    {
        public static void SpawnPanelSystem(string packageName, string panelName, ComponentInfo componentInfo, bool isSubPanel = false, VariableInfo variableInfo = null)
        {
            string fileDir = "{0}/{1}".Fmt(FUICodeSpawner.HotfixViewCodeDir, packageName);
            if (!Directory.Exists(fileDir))
            {
                Directory.CreateDirectory(fileDir);
            }

            StringBuilder sb = new StringBuilder();
            string filePath = "{0}/{1}System.cs".Fmt(fileDir, panelName);
            if (File.Exists(filePath))
            {
                return;
            }
            
            Debug.Log("Spawn Code For PanelSystem {0}".Fmt(filePath));
            
            sb.AppendFormat("namespace {0}", FUICodeSpawner.NameSpace);
            sb.AppendLine();
            sb.AppendLine("{");

            if (isSubPanel)
            {
                sb.AppendLine($"\tpublic class {panelName}AwakeSystem : AwakeSystem<{panelName}, {variableInfo.TypeName}>");
                sb.AppendLine("\t{");
                sb.AppendLine($"\t\tprotected override void Awake({panelName} self, {variableInfo.TypeName} fui{panelName})");
                sb.AppendLine("\t\t{");
                sb.AppendLine($"\t\t\tself.Awake(fui{panelName});");
                sb.AppendLine("\t\t}");
                sb.AppendLine("\t}");
                sb.AppendLine();
            }
            
            sb.AppendLine($"\t[FriendOf(typeof({panelName}))]");
            sb.AppendFormat("\tpublic static class {0}System", panelName);
            sb.AppendLine();
            sb.AppendLine("\t{");

            if (isSubPanel)
            {
                sb.AppendLine($"\t\tpublic static void Awake(this {panelName} self, {variableInfo.TypeName} fui{panelName})");
                sb.AppendLine($"\t\t{{");
                sb.AppendLine($"\t\t\tself.FUI{panelName} = fui{panelName};");
            }
            else
            {
                sb.AppendLine($"\t\tpublic static void Awake(this {panelName} self)");
                sb.AppendLine($"\t\t{{");
            }
            
            // 子组件
            List<string> subComNames = new List<string>();
            componentInfo.VariableInfos.ForEach(variableInfo =>
            {
                if (!variableInfo.IsExported)
                {
                    return;
                }

                if (variableInfo.RealTypeName != "GComponent")
                {
                    return;
                }

                int index = variableInfo.TypeName.IndexOf("FUI_", StringComparison.Ordinal);
                string comName = variableInfo.TypeName.Substring(index + 4);
                subComNames.Add(variableInfo.VariableName);
                sb.AppendLine($"\t\t\tself.{variableInfo.VariableName} = self.AddChild<{comName}, {variableInfo.TypeName}>(self.FUI{panelName}.{variableInfo.VariableName}, true);");
            });
            
            sb.AppendLine("\t\t}");
            
            sb.AppendLine();
            sb.AppendFormat("\t\tpublic static void RegisterUIEvent(this {0} self)", panelName);
            sb.AppendLine();
            sb.AppendLine("\t\t{");
            subComNames.ForEach(comName =>
            {
                sb.AppendLine($"\t\t\tself.{comName}.RegisterUIEvent();");
            });
            sb.AppendLine("\t\t}");
            
            sb.AppendLine();
            sb.AppendFormat("\t\tpublic static void OnShow(this {0} self, Entity contextData = null)", panelName);
            sb.AppendLine();
            sb.AppendLine("\t\t{");
            subComNames.ForEach(comName =>
            {
                sb.AppendLine($"\t\t\tself.{comName}.OnShow();");
            });
            sb.AppendLine("\t\t}");
            
            sb.AppendLine();
            sb.AppendFormat("\t\tpublic static void OnHide(this {0} self)", panelName);
            sb.AppendLine();
            sb.AppendLine("\t\t{");
            subComNames.ForEach(comName =>
            {
                sb.AppendLine($"\t\t\tself.{comName}.OnHide();");
            });
            sb.AppendLine("\t\t}");
            
            sb.AppendLine();
            sb.AppendFormat("\t\tpublic static void BeforeUnload(this {0} self)", panelName);
            sb.AppendLine();
            sb.AppendLine("\t\t{");
            subComNames.ForEach(comName =>
            {
                sb.AppendLine($"\t\t\tself.{comName}.BeforeUnload();");
            });
            sb.AppendLine("\t\t}");
            
            sb.AppendLine("\t}");
            sb.Append("}");
            
            using FileStream fs = new FileStream(filePath, FileMode.Create);
            using StreamWriter sw = new StreamWriter(fs);
            sw.Write(sb.ToString());
        }
    }
}