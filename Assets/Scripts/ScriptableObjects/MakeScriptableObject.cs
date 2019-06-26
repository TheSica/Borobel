using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeScriptableObject
{
	[MenuItem("Assets/Create/ReadeableScriptableObject")]
	public static void CreateMyAsset()
	{
		ReadeableScriptableObject asset = ScriptableObject.CreateInstance<ReadeableScriptableObject>();

		AssetDatabase.CreateAsset(asset, "Assets/Scripts/ScriptableObjects/ReadeableScriptableObject.asset");
		AssetDatabase.SaveAssets();

		EditorUtility.FocusProjectWindow();

		Selection.activeObject = asset;
	}
}