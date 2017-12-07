#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CameraBehavior))]
public class CameraBehaviorEditor : Editor
{
	public SerializedProperty cameraMode;
	public SerializedProperty cameraOffset;
	public SerializedProperty horizontalMaxDistance;
	public SerializedProperty horizontalLerpSpeed;

	void OnEnable()
	{
		cameraOffset = serializedObject.FindProperty("offset");
		horizontalMaxDistance = serializedObject.FindProperty("maxDistance");
		horizontalLerpSpeed = serializedObject.FindProperty("lerpSpeed");

		cameraMode = serializedObject.FindProperty("mode");
	}

	override public void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.PropertyField(cameraMode, new GUIContent("Mode"));

		switch ((CameraBehavior.CameraMode)cameraMode.enumValueIndex)
		{
			case CameraBehavior.CameraMode.Direct:
			{
				EditorGUILayout.PropertyField(cameraOffset, new GUIContent("Offset"));
				break;
			};
			case CameraBehavior.CameraMode.Horizontal:
			{
				EditorGUILayout.PropertyField(horizontalMaxDistance, new GUIContent("Max Distance"));
				EditorGUILayout.PropertyField(horizontalLerpSpeed, new GUIContent("Lerp Speed"));
				break;
			}
			case CameraBehavior.CameraMode.Static:
			{
				break;
			}
		}

		serializedObject.ApplyModifiedProperties();
	}
}
#endif