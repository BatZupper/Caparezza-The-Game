using UnityEngine;
using UnityEngine.SceneManagement;

public class Caparezzino : MonoBehaviour
{
    private int clickCount = 0;
    public int requiredClicks = 10;
    public string targetSceneName = "TargetScene"; // Il nome della scena in cui vuoi andare
    public KeyCode clickKey = KeyCode.E; // Il tasto che il giocatore deve premere

    void Update()
    {
        // Crea un ray dal centro della telecamera
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        // Controlla se il ray colpisce un oggetto
        if (Physics.Raycast(ray, out hit))
        {
            // Controlla se l'oggetto colpito è lo stesso di questo script
            if (hit.transform == transform)
            {
                // Controlla se il giocatore preme il tasto specificato
                if (Input.GetKeyDown(clickKey))
                {
                    clickCount++;
                    Debug.Log("Clic conteggiato: " + clickCount);

                    if (clickCount >= requiredClicks)
                    {
                        SceneManager.LoadScene(targetSceneName);
                    }
                }
            }
        }
    }
}
