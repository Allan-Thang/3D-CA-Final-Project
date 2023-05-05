using UnityEngine;
using UnityEditor;
using System.IO;
using System.Reflection;

public static class DebugMenu {

	private static GameObject GetGameObjectFromFileID(long fileID) // also called local identifier
	{
		GameObject resultGo = null;
		var gameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
		// Test every gameobjects
		foreach (var go in gameObjects)
		{
			#if UNITY_EDITOR
			PropertyInfo inspectorModeInfo = typeof(UnityEditor.SerializedObject).GetProperty("inspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);
			UnityEditor.SerializedObject serializedObject = new UnityEditor.SerializedObject(go);
			inspectorModeInfo.SetValue (serializedObject, UnityEditor.InspectorMode.Debug, null);
			UnityEditor.SerializedProperty localIdProp = serializedObject.FindProperty ("m_LocalIdentfierInFile");
			#endif
			if(localIdProp.longValue == fileID) resultGo = go;
		}
		// Test every gameobjects transforms
		foreach (var go in gameObjects)
		{
			#if UNITY_EDITOR
			PropertyInfo inspectorModeInfo = typeof(UnityEditor.SerializedObject).GetProperty("inspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);
			UnityEditor.SerializedObject serializedObject = new UnityEditor.SerializedObject(go.transform);
			inspectorModeInfo.SetValue (serializedObject, UnityEditor.InspectorMode.Debug, null);
			UnityEditor.SerializedProperty localIdProp = serializedObject.FindProperty ("m_LocalIdentfierInFile");
			#endif
			if(localIdProp.longValue == fileID) resultGo = go;
		}
		return resultGo;
	}

	[MenuItem("Debug/Show gameobject from fileID")]
	public static void ShowGameObject()
	{
		// Warning, only working in editor
		long fileID = 2;
		GameObject resultGo = GetGameObjectFromFileID(fileID);
		if (resultGo == null)
		{
			Debug.LogError("FileID not found for fileID = " + fileID);
			return;
		}
		Debug.Log("GameObject for fileID " + fileID + " is " + resultGo, resultGo);
		GameObject[] newSelection = new GameObject[]{resultGo};
	Selection.objects = newSelection;
	}
}