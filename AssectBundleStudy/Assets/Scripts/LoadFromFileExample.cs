using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class LoadFromFileExample : MonoBehaviour
{
    string path = "AssetBundles/cubewall.nan";
    IEnumerator Start()
    {
        //AssetBundle ab = AssetBundle.LoadFromFile("AssetBundles/share.nan");
        //AssetBundle ab1 = AssetBundle.LoadFromFile("AssetBundles/cubewall.nan");
        //GameObject go = ab1.LoadAsset<GameObject>("CubeWall");
        //Instantiate(go);


        //第一种AssetBundle加载方式   AssetBundle.LoadFromMemory
        //AssetBundle ab = AssetBundle.LoadFromMemory(File.ReadAllBytes(path));
        //GameObject go = ab.LoadAsset<GameObject>("CubeWall");
        //Instantiate(go);

        //第二种AssetBunbdle加载方式  AssetBundle.LoadFromFileAsync
        //AssetBundleCreateRequest assetBundleCreate = AssetBundle.LoadFromFileAsync(path);
        //AssetBundle ab = assetBundleCreate.assetBundle;
        //GameObject go = ab.LoadAsset<GameObject>("CubeWall");
        //Instantiate(go);

        //第三种AssetBundle加载方式  WWW.LoadFromCacheOrDownload
        while (Caching.ready == false)
            yield return null;

        WWW ww = WWW.LoadFromCacheOrDownload(@"F:\NanProject\AssectBundleStudy\AssectBundleStudy\AssectBundleStudy\AssetBundles\cubewall.nan", 1);
        yield return ww;
        if (ww.error != null)
        {
            Debug.Log(ww.error);
            yield break;
        }
        if (ww.isDone)
        {
            AssetBundle ab = ww.assetBundle;
            GameObject go = ab.LoadAsset<GameObject>("CubeWall");
            Instantiate(go);
        }

    }
}
