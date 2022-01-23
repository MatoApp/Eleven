using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;

namespace MatoApp.Automators
{
    /// <summary>
    /// Enum自動生成クラス
    /// </summary>
    internal static class EnumGenerator
    {
        private static string Code { get; set; } = "";
        private static string Tab { get; set; } = "";

        private static void Initialize(string nameSpace, string summary, bool isFlags, string enumName)
        {
            Code = "";
            Tab = "";

            if (!string.IsNullOrEmpty(nameSpace))
            {
                Code += "namespace " + nameSpace + "\n" + Tab + "{\n";
                Tab += "\t";
            }

            if (!string.IsNullOrEmpty(summary))
            {
                Code +=
                  Tab + "/// <summary>\n" +
                  Tab + "/// " + summary + "\n" +
                  Tab + "/// </summary>\n";
            }

            if (isFlags)
            {
                Code += Tab + "[System.Flags]\n";
            }

            Code += Tab + "public enum " + enumName + "\n" + Tab + "{\n";

            Tab += "\t";
        }

        private static void Export(string exportPath, string nameSpace, string enumName)
        {
            if (!string.IsNullOrEmpty(nameSpace))
            {
                Code += "\t}\n";
            }

            Code += "}";

            File.WriteAllText(exportPath, Code, Encoding.UTF8);
            AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);

            EditorUtility.DisplayDialog("Notion", $"{enumName} is generated.", "OK");
        }

        public static void Generate(string enumName, List<string> itemList, string exportPath, string summary = "", string nameSpace = "", bool isFlags = false)
        {
            Initialize(nameSpace, summary, isFlags, enumName);

            var nameLengthMax = 0;
            if (itemList.Count > 0)
            {
                nameLengthMax = itemList.Select(name => name.Length).Max();
            }

            for (var i = 0; i < itemList.Count; i++)
            {
                Code += Tab + itemList[i];
                Code += " " + String.Format("{0, " + (nameLengthMax - itemList[i].Length + 1).ToString() + "}", "=");

                if (isFlags)
                {
                    Code += " 1 << " + i.ToString() + ",\n";
                }
                else
                {
                    Code += " " + i.ToString() + ",\n";
                }
            }

            Export(exportPath, nameSpace, enumName);
        }

        public static void Generate(string enumName, Dictionary<string, int> itemDict, string exportPath, string summary = "", string nameSpace = "")
        {
            Initialize(nameSpace, summary, false, enumName);

            var nameLengthMax = 0;
            if (itemDict.Keys.Count > 0)
            {
                nameLengthMax = itemDict.Keys.Select(name => name.Length).Max();
            }

            foreach (var item in itemDict)
            {
                Code += Tab + item.Key;
                Code += " " + String.Format("{0, " + (nameLengthMax - item.Key.Length + 1).ToString() + "}", "=");
                Code += " " + item.Value.ToString() + ",\n";
            }

            Export(exportPath, nameSpace, enumName);
        }
    }
}
