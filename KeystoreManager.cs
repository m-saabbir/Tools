using System.IO;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class OnInitialize
{
    static OnInitialize()
    {
        if (!SessionState.GetBool("KeystoreManager", false))
        {
            ScriptableObject.CreateInstance<KeystoreManager>().ApplyKeystoreSettings();
            SessionState.SetBool("KeystoreManager", true);
        }
    }
}

public class KeystoreManager : EditorWindow
{
    private const string keystoreSettingPath = "KeystoreManager.json";
    private SerializedObject serializedObject;
    private SerializedProperty serializedProperty;
    public KeystoreSetting keystoreSetting;

    private void OnEnable()
    {
        serializedObject ??= new SerializedObject(this);
        serializedProperty = serializedObject.FindProperty("keystoreSetting");
        keystoreSetting = File.Exists(keystoreSettingPath) ? JsonUtility.FromJson<KeystoreSetting>(File.ReadAllText(keystoreSettingPath)) : new();

        ApplyKeystoreSettings();
    }

    private void OnDisable()
    {
        File.WriteAllText(keystoreSettingPath, JsonUtility.ToJson(keystoreSetting, true));
    }

    private void OnGUI()
    {
        using (new GUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUILayout.PropertyField(serializedProperty, true);

            if (serializedObject.ApplyModifiedProperties())
            {
                ApplyKeystoreSettings();
            }
        }
    }

    public void ApplyKeystoreSettings()
    {
        if (keystoreSetting != null)
        {
            PlayerSettings.Android.keystorePass = keystoreSetting.keystorePassword;
            PlayerSettings.Android.keyaliasPass = keystoreSetting.aliasPassword;
        }
    }

    [System.Serializable]
    public class KeystoreSetting
    {
        public string keystorePassword;
        public string aliasPassword;

        public KeystoreSetting()
        {
            keystorePassword = PlayerSettings.Android.keystorePass;
            aliasPassword = PlayerSettings.Android.keyaliasPass;
        }
    }

    [MenuItem("Tools/Keystore Manager", false, -200)]
    private static void ShowWindow()
    {
        var window = GetWindow<KeystoreManager>(true, "Keystore Manager");
        window.minSize = new Vector2(370f, 70f);
    }
}