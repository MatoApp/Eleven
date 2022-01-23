using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using MatoApp.Utilities;

namespace MatoApp.Automators
{
    /// <summary>
    /// SceneのEnumを自動生成するクラス
    /// </summary>
    [CreateAssetMenu(
        fileName = "Assets/Automators/SceneEnumGenerator.asset",
        menuName = "Automators/Scene Enum Generator")]
    internal class SceneEnumGenerator : SerializedScriptableObject
    {
        [SerializeField]
        private string NameSpace { get; set; }
        [SerializeField]
        private string EnumName { get; set; }
        [SerializeField]
        private string ExportFilePath { get; set; }
        [SerializeField]
        private string EscapePattern { get; set; }
        [SerializeField]
        private string Summary { get; set; }

        [Button]
        private void Generate()
        {
            var sceneNameList = new List<string>();

            var names = EditorBuildSettings.scenes
                .Select(x => Path.GetFileNameWithoutExtension(x.path))
                .Select(x => Regex.Replace(x, $"[{EscapePattern}]", ""))
                .Select(x => Regex.Replace(x, "Scene", ""))
                .Distinct();

            foreach (var name in names)
            {
                sceneNameList.Add(name);
            }

            EnumGenerator.Generate(
                enumName: EnumName,
                itemList: sceneNameList,
                exportPath: ExportFilePath,
                nameSpace: NameSpace,
                summary: Summary
              );
        }

        [Button]
        private void Copy()
        {
            GUIUtility.systemCopyBuffer = $"NameSpace:{NameSpace};EnumName:{EnumName};ExportFilePath:{ExportFilePath};EscapePattern:{EscapePattern};Summary:{Summary}";

            EditorUtility.DisplayDialog("Notion", "Copied.", "OK");
        }

        [Button]
        private void Paste()
        {
            var fields = Regex.Split(GUIUtility.systemCopyBuffer, ";")
                .Select(x => Regex.Split(x, ":"))
                .ToDictionary(x => x[0], x => x[1]);

            NameSpace = fields["NameSpace"];
            EnumName = fields["EnumName"];
            ExportFilePath = fields["ExportFilePath"];
            EscapePattern = fields["EscapePattern"];
            Summary = fields["Summary"];
        }
    }
}
