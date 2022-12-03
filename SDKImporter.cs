// Download and Import: External Dependency Manager, Facebook, AppsFlyer, GameAnalytics

#if UNITY_EDITOR
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Net.Http;

public class SDKImporter
{
    private const string url_dm = "https://github.com/googlesamples/unity-jar-resolver/raw/master/external-dependency-manager-latest.unitypackage";
    private const string url_kv = "https://github.com/arifurrahman-devtools/ptsd-kit/releases/download/v0.1.1/PTSDKit_0.1.1.unitypackage";
    private const string url_fb = "https://github.com/SAA33IR/Stable-SDKs/raw/main/facebook.unitypackage";
    private const string url_af = "https://github.com/AppsFlyerSDK/appsflyer-unity-plugin/raw/master/appsflyer-unity-plugin-6.8.5.unitypackage";
    private const string url_ga = "https://download.gameanalytics.com/unity/GA_SDK_UNITY.unitypackage";

    [MenuItem("Tools/Import SDK/External Dependency Manager", false, 0)]
    private static void EDM() => GetUnityPackage(url_dm, "ExternalDependencyManager.unitypackage");

    [MenuItem("Tools/Import SDK/PTSD Kit", false, 20)]
    private static void PTSDKit() => GetUnityPackage(url_kv, "PTSDKit.unitypackage");

    [MenuItem("Tools/Import SDK/Facebook", false, 40)]
    private static void FB() => GetUnityPackage(url_fb, "facebook.unitypackage");

    [MenuItem("Tools/Import SDK/AppsFlyer", false, 41)]
    private static void AF() => GetUnityPackage(url_af, "AppsFlyer.unitypackage");

    [MenuItem("Tools/Import SDK/GameAnalytics",false, 42)]
    private static void GA() => GetUnityPackage(url_ga, "GameAnalytics.unitypackage");

    private static async void GetUnityPackage(string url, string fileName)
    {
        var client = new HttpClient();
        var response = await client.GetAsync(url);
        var contents = await response.Content.ReadAsByteArrayAsync();
        File.WriteAllBytes(fileName, contents);
        AssetDatabase.ImportPackage(fileName, true);
        File.Delete(fileName);
    }
}
#endif
