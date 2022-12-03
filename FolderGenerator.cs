// Generate Default(Custom) Folder

#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using System.Collections.Generic;

public class FolderGenerator
{
    [MenuItem("Tools/Generate Folders")]
    private static void GenerateFolders()
    {
        List<string> folders = new List<string> { "_Arts", "_Prefabs", "_Scenes", "_Scripts", "_UI", "Externals" };
        
        foreach (string folder in folders)
        {
            if (!Directory.Exists("Assets/" + folder))
            {
                Directory.CreateDirectory("Assets/" + folder);
            }
        }

        List<string> artsFolders = new List<string>{"Animations", "Materials", "Models", "Particles", "Textures"};

        foreach (string artsFolder in artsFolders)
        {
            if (!Directory.Exists("Assets/_Arts/" + artsFolder))
            {
                Directory.CreateDirectory("Assets/_Arts/" + artsFolder);
            }
        }

        List<string> uiFolders = new List<string> {"Fonts", "Icons", "Sprites"};

        foreach (string uiFolder in uiFolders)
        {
            if (!Directory.Exists("Assets/_UI/" + uiFolder))
            {
                Directory.CreateDirectory("Assets/_UI/" + uiFolder);
            }
        }

        AssetDatabase.Refresh();
    }
}
#endif
