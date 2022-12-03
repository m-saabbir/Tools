#if UNITY_EDITOR
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Net.Http;

public class SDKImporter
{
    private const string url_edm = "https://raw.githubusercontent.com/googlesamples/unity-jar-resolver/master/external-dependency-manager-latest.unitypackage";
    private const string url_af = "https://raw.githubusercontent.com/AppsFlyerSDK/appsflyer-unity-plugin/master/appsflyer-unity-plugin-6.8.5.unitypackage";
    private const string url_ga = "https://download.gameanalytics.com/unity/GA_SDK_UNITY.unitypackage";

    [MenuItem("Tools/Import SDK/AppsFlyer")]
    private static async void AF()
    {
        string fileName = "AppsFlyer.unitypackage";
        var client = new HttpClient();
        var response = await client.GetAsync(url_af);
        var contents = await response.Content.ReadAsByteArrayAsync();
        File.WriteAllBytes(fileName, contents);
        AssetDatabase.ImportPackage(fileName, true);
        File.Delete(fileName);
    }


    [MenuItem("Tools/Import SDK/External Dependency Manager")]
    private static async void EDM()
    {
        string fileName = "ExternalDependencyManager.unitypackage";
        var client = new HttpClient();
        var response = await client.GetAsync(url_edm);
        var contents = await response.Content.ReadAsByteArrayAsync();
        File.WriteAllBytes(fileName, contents);
        AssetDatabase.ImportPackage(fileName, true);
        File.Delete(fileName);
    }

    [MenuItem("Tools/Import SDK/GameAnalytics")]
    private static async void GA()
    {
        string fileName = "GameAnalytics.unitypackage";
        var client = new HttpClient();
        var response = await client.GetAsync(url_ga);
        var contents = await response.Content.ReadAsByteArrayAsync();
        File.WriteAllBytes(fileName, contents);
        AssetDatabase.ImportPackage(fileName, true);
        File.Delete(fileName);
    }
}
#endif
