using UnityEngine;
using System.IO;

public class CreateTXT : MonoBehaviour
{

    string TTRName = Application.streamingAssetsPath + "/Easter eggs/" + "TTR Risolto" + ".txt";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Easter eggs/");

        if(!File.Exists(TTRName))
        {
            File.WriteAllText(TTRName, "https://www.youtube.com/watch?v=4OBemEilMok");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
