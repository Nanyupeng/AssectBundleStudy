using UnityEditor;
using System.IO;
public class CreatAssetBundles 
{
    [MenuItem("Assets/Build AssetBundles")]
   static void BuildALLAssetBundles()
    {
        string dr = "AssetBundles";
        if (!Directory.Exists(dr))
            Directory.CreateDirectory(dr);
        BuildPipeline.BuildAssetBundles(dr, BuildAssetBundleOptions.None,BuildTarget.StandaloneWindows64);
    }
}
