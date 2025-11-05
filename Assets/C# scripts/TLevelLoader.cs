
using UnityEngine;
using UnityEngine.SceneManagement;

public class TLevelLoader : MonoBehaviour
{
    public string scene;

    void OnTriggerEnter()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene(scene);
    }
}
