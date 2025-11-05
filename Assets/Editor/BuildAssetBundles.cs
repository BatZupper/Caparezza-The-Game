using UnityEditor;
using UnityEngine;

public class BuildAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        // Definisci il percorso della cartella in cui verranno salvati gli AssetBundles
        string assetBundleDirectory = "Assets/Arcade_Maps";

        // Crea la cartella se non esiste
        if (!System.IO.Directory.Exists(assetBundleDirectory))
        {
            System.IO.Directory.CreateDirectory(assetBundleDirectory);
        }

        // Costruisci gli AssetBundles
        BuildPipeline.BuildAssetBundles(assetBundleDirectory,
                                        BuildAssetBundleOptions.None,
                                        BuildTarget.StandaloneWindows);

        Debug.Log("AssetBundles costruiti con successo!");
    }
}
