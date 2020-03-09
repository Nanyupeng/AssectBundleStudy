using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
public class LoadFromFileExample : MonoBehaviour
{
    string path = "AssetBundles/cubewall.nan";
    void Start()
    {
        //AssetBundle ab = AssetBundle.LoadFromFile("AssetBundles/share.nan");
        //AssetBundle ab1 = AssetBundle.LoadFromFile("AssetBundles/cubewall.nan");
        //GameObject go = ab1.LoadAsset<GameObject>("CubeWall");
        //Instantiate(go);


        //第一种AssetBundle加载方式 AssetBundle.LoadFromMemory
        //AssetBundle ab = AssetBundle.LoadFromMemory(File.ReadAllBytes(path));
        //GameObject go = ab.LoadAsset<GameObject>("CubeWall");
        //Instantiate(go);

        //第二种AssetBunbdle加载方式  AssetBundle.LoadFromFileAsync
        //AssetBundleCreateRequest assetBundleCreate = AssetBundle.LoadFromFileAsync(path);
        //AssetBundle ab = assetBundleCreate.assetBundle;
        //GameObject go = ab.LoadAsset<GameObject>("CubeWall");
        //Instantiate(go);

        //第三种AssetBundle加载方式  WWW.LoadFromCacheOrDownload
        //while (Caching.ready == false)
        //    yield return null;

        //WWW ww = WWW.LoadFromCacheOrDownload(@"F:\NanProject\AssectBundleStudy\AssectBundleStudy\AssectBundleStudy\AssetBundles\cubewall.nan", 1);
        //yield return ww;
        //if (ww.error != null)
        //{
        //    Debug.Log(ww.error);
        //    yield break;
        //}
        //if (ww.isDone)
        //{
        //    AssetBundle ab = ww.assetBundle;
        //    GameObject go = ab.LoadAsset<GameObject>("CubeWall");
        //    Instantiate(go);
        //}

        StartCoroutine("UnityWebRequests");
    }

    IEnumerator UnityWebRequests()
    {
        
        //第四种Assetbundle加载方式 UnityWebRequest
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle("http://127.0.0.1/" + path);
        yield return request.SendWebRequest();
        //byte[] bytes = request.downloadHandler.data;
        //Debug.Log(request.downloadHandler.data);
        //File.WriteAllBytes(Application.dataPath + "/Prefabs/", bytes);


        //FileStream fs = new FileStream("Prefabs", FileMode.Append, FileAccess.ReadWrite);
        //BinaryWriter bw = new BinaryWriter(fs);
        //fs.Write(bytes, 0, bytes.Length);
        //fs.Flush();     //流会缓冲，此行代码指示流不要缓冲数据，立即写入到文件。
        //fs.Close();     //关闭流并释放所有资源，同时将缓冲区的没有写入的数据，写入然后再关闭。
        //fs.Dispose();   //释放流
        //request.Dispose();


        //AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);
        //GameObject go = ab.LoadAsset<GameObject>("Cubewall");
        //Instantiate(go);
    }
}
