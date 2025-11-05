using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int health = 100;

    public string scene; 

    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(health.ToString());
        

        if (health <= 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            text.SetText("GameOver");

            if(Input.GetMouseButtonDown(0)) 
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
}
