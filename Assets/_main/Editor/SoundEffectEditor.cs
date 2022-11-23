using UnityEngine;
using UnityEditor;
using ScriptableObjects;

[CustomEditor(typeof(SoundEffectSO), true)]
public class SoundEffectEditor : Editor
{

    [SerializeField] private AudioSource _previewer;

    public void OnEnable()
    {
        _previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio Preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
    }

    public void OnDisable()
    {
        DestroyImmediate(_previewer.gameObject);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
        if (GUILayout.Button("Preview"))
        {
            ((SoundEffectSO)target).Play(_previewer);
        }
        EditorGUI.EndDisabledGroup();
    }
}