#if UNITY_EDITOR
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Net.Http;

public class GitignoreGenerator
{
    private const string url = "https://gist.github.com/SAA33IR/427c9d60a9d862bf21d3e97c7b86cac3/raw";
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
