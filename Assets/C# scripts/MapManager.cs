using UnityEngine;
using TMPro;

public class MapManager : MonoBehaviour
{
    [SerializeField] GunSystem gunSystem;

    bool MappaAttiva = false;

    public GameObject mappa;
    public GameObject player;

    public TextMeshProUGUI matrimoni_salvati_text;
    public TextMeshProUGUI best_matrimoni_text;

    void Update()
    {
        matrimoni_salvati_text.SetText(gunSystem.Matrimoni_salvati.ToString());
        best_matrimoni_text.SetText(gunSystem.Best_matrimoni.ToString());

        if (Input.GetKeyDown("m"))
        {
            if (MappaAttiva == false)
            {
                mappa.SetActive(true);
                player.SetActive(true);
                MappaAttiva = true;
            }
            else
            {
                player.SetActive(false);
                mappa.SetActive(false);
                MappaAttiva = false;
            }

        }
    }
}
