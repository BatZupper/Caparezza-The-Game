using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class ACE_Dialogue : MonoBehaviour
{
    [Header("TextMeshPro Elements")]
    public TMP_Text dialogText; // TextMeshPro component for the dialog
    public TMP_Text option1Text; // TextMeshPro component for the first option button
    public TMP_Text option2Text; // TextMeshPro component for the second option button

    [SerializeField] Wait wait;

    private string jsonFilePath;

    // Structs to match the JSON structure
    [System.Serializable]
    public class Option
    {
        public string text;
        public int nextNode; // ID of the next dialog node
    }

    [System.Serializable]
    public class DialogNode
    {
        public int id;
        public string dialog;
        public Option option1;
        public Option option2;
    }

    [System.Serializable]
    public class DialogData
    {
        public List<DialogNode> nodes;
    }

    private DialogData dialogData;
    public int currentNodeId = 0;

    void Start()
    {
        // Path to the JSON file
        jsonFilePath = Path.Combine(Application.streamingAssetsPath, "ACE.json");

        // Start loading the dialog
        StartCoroutine(LoadDialogFromFile());
    }

    // Coroutine to load the dialog asynchronously
    IEnumerator LoadDialogFromFile()
    {
        string jsonData;

        // Handle reading from StreamingAssets on Android (special case for Android platform)
        if (jsonFilePath.Contains("://") || jsonFilePath.Contains(":///"))
        {
            using (WWW www = new WWW(jsonFilePath))
            {
                yield return www;
                jsonData = www.text;
            }
        }
        else
        {
            jsonData = File.ReadAllText(jsonFilePath);
        }

        // Parse the JSON data
        dialogData = JsonUtility.FromJson<DialogData>(jsonData);

        // Load the first dialog node
        LoadNode(currentNodeId);
    }

    // Load a dialog node based on its ID
    void LoadNode(int nodeId)
    {
        DialogNode node = dialogData.nodes.Find(n => n.id == nodeId);

        if (node != null)
        {
            dialogText.text = node.dialog;
            option1Text.text = node.option1.text;
            option2Text.text = node.option2.text;

            // Set button actions based on the next node
            option1Text.transform.parent.GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
            option1Text.transform.parent.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnOptionClick(node.option1.nextNode));

            option2Text.transform.parent.GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
            option2Text.transform.parent.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnOptionClick(node.option2.nextNode));
        }
        else
        {
            Debug.LogError("Node ID not found: " + nodeId);
        }
    }

    // Handle option clicks and load the next node
    async void OnOptionClick(int nextNodeId)
    {
        if (nextNodeId > -1)
        {
            LoadNode(nextNodeId);
        }
        else if (nextNodeId == -1)
        {
            dialogText.text = "Finale 1: Ti sei arreso";
            option1Text.text = "Premi esc";
            option2Text.text = "Per uscire";
        }
        else if (nextNodeId == -2)
        {
            dialogText.text = "Finale 2: Sei morto";
            option1Text.text = "Premi esc";
            option2Text.text = "Per uscire";
        }
        else if (nextNodeId == -3)
        {
            dialogText.text = "Finale 3: hai preso la roba sbagliata";
            option1Text.text = "Premi esc";
            option2Text.text = "Per uscire";
        }

        if (nextNodeId == 1000)
        {
            wait.wait(2.276f);
            LoadNode(15);
        }
    }
}
