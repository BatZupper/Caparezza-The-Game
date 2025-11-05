
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string _scene;

    public void LoadScene()
    {
        SceneManager.LoadScene(_scene);
    }
}
