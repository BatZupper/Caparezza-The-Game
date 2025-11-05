using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PugliaLoader : MonoBehaviour
{
    public TMP_Dropdown sceneDropdown; // Riferimento al Dropdown
    public TMP_Text statusText; // Riferimento a un TextMeshPro per mostrare messaggi di stato
    private AssetBundle loadedAssetBundle;
    private string[] scenePaths;
    public string Map_folder;

    void Start()
    {
        StartCoroutine(LoadAllAssetBundles()); // Carica tutti gli AssetBundles
    }

    IEnumerator LoadAllAssetBundles()
    {
        string MapsPath = Path.Combine(Application.streamingAssetsPath, Map_folder);

        // Controlla se la cartella esiste
        if (!Directory.Exists(MapsPath))
        {
            Debug.LogError("La cartella Arcade_Maps non esiste!");
            yield break;
        }

        // Ottieni tutti i file nella cartella Arcade_Maps
        string[] assetBundleFiles = Directory.GetFiles(MapsPath, "*.bundle"); // Assicurati di usare l'estensione corretta

        if (assetBundleFiles.Length == 0)
        {
            Debug.LogError("Nessun AssetBundle trovato nella cartella");
            yield break;
        }

        // Carica ogni AssetBundle e ottieni le scene
        foreach (string bundlePath in assetBundleFiles)
        {
            AssetBundleCreateRequest bundleLoadRequest = AssetBundle.LoadFromFileAsync(bundlePath);
            yield return bundleLoadRequest;

            loadedAssetBundle = bundleLoadRequest.assetBundle;

            if (loadedAssetBundle == null)
            {
                Debug.LogError($"Failed to load AssetBundle from {bundlePath}!");
                continue; // Continua con il prossimo AssetBundle se il caricamento fallisce
            }

            // Ottieni i percorsi delle scene nell'AssetBundle
            string[] bundleScenePaths = loadedAssetBundle.GetAllScenePaths();
            scenePaths = scenePaths == null ? bundleScenePaths : CombineScenePaths(scenePaths, bundleScenePaths);
        }

        PopulateDropdown();
    }

    string[] CombineScenePaths(string[] existingPaths, string[] newPaths)
    {
        string[] combined = new string[existingPaths.Length + newPaths.Length];
        existingPaths.CopyTo(combined, 0);
        newPaths.CopyTo(combined, existingPaths.Length);
        return combined;
    }

    void PopulateDropdown()
    {
        sceneDropdown.ClearOptions(); // Pulisce le opzioni esistenti

        // Aggiungi le scene come opzioni nel Dropdown
        foreach (string scenePath in scenePaths)
        {
            string sceneName = Path.GetFileNameWithoutExtension(scenePath); // Ottieni solo il nome della scena
            sceneDropdown.options.Add(new TMP_Dropdown.OptionData(sceneName));
        }

        sceneDropdown.RefreshShownValue(); // Aggiorna il dropdown per mostrare le nuove opzioni
    }

    public void LoadScene()
    {
        if (loadedAssetBundle == null)
        {
            Debug.LogError("AssetBundle not loaded!");
            return;
        }

        // Ottieni il nome della scena selezionata
        string sceneName = sceneDropdown.options[sceneDropdown.value].text;
        string scenePath = System.Array.Find(scenePaths, path => path.Contains(sceneName));

        if (scenePath == null)
        {
            Debug.LogError("Scene not found in AssetBundle!");
            return;
        }

        // Carica la scena
        SceneManager.LoadScene(scenePath);
        statusText.text = $"Caricando: {sceneName}"; // Mostra un messaggio di stato
    }

    void OnDestroy()
    {
        if (loadedAssetBundle != null)
        {
            loadedAssetBundle.Unload(false);
        }
    }
}
