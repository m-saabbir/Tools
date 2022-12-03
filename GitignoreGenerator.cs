// Generate .gitignore in Project Folder

#if UNITY_EDITOR
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Net.Http;

public class GitignoreGenerator
{
    private const string url = "https://raw.githubusercontent.com/github/gitignore/main/Unity.gitignore";
    private const string filename = ".gitignore";

    [MenuItem("Tools/Generate .gitignore")]
    private static async void GetManifest()
    {
        var client = new HttpClient();
        var response = await client.GetAsync(url);
        var contents = await response.Content.ReadAsStringAsync();
        File.WriteAllText(filename, contents);
        Debug.Log(".gitignore Generated");
    }
}
#endif
