using UnityEngine;
using UnityEngine.SceneManagement;

public class Distributore : MonoBehaviour
{
    string input;

    bool inArea = false;
    bool isUiActive = false;

    public GameObject UI;

    public void ReadString(string s)
    {
        input = s;
    }

    // Update is called once per frame
    void Update()
    {
        if (inArea == true)
        {
            if (Input.GetKeyDown("e"))
            {
                UI.SetActive(true);
                isUiActive = true;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;

            }
        }

        if (input == "CAPAREZZA")
        {
            SceneManager.LoadScene("Test Material");
        }

        if (Input.GetKeyDown("escape"))
        {
            if(isUiActive == true)
            {
                UI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        inArea = true;
    }

    void OnTriggerExit(Collider other)
    {
        inArea = false;
    }
}
