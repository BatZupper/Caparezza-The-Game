using System.Collections;
using UnityEngine;
using TMPro;

public class TD_Manager : MonoBehaviour
{
    public int money = 100;
    int prefabScelto = 0;

    // Prefab che verrà istanziato
    public GameObject Caparezza;
    public GameObject Caparezzino;
    public GameObject CaparezzinoVero;
    public GameObject Ilaria;
    public GameObject Luigi;
    public GameObject Bonobbo;

    public GameObject GameOver;
    public GameObject Win;

    // Piano su cui il prefab verrà istanziato
    public LayerMask layerMask;

    public TextMeshProUGUI play;
    public TextMeshProUGUI Money;

    Quaternion rotation = Quaternion.Euler (0, 90, 0);

    [SerializeField] TDSpawner tdspawner;
    [SerializeField] TDMolfetta tdmolfetta;

    void Start()
    {
        money = 100;
    }

    void Update()
    {
        // Controlla se l'utente ha cliccato con il tasto sinistro del mouse
        if (Input.GetMouseButtonDown(0))
        {
            SpawnPrefabAtMousePosition();
        }

        if(tdmolfetta.health < 1)
        {
            GameOver.SetActive(true);
        }

        play.SetText("Inizia round " + (tdspawner.rounds + 1).ToString());
        Money.SetText(money.ToString());
    }

    void SpawnPrefabAtMousePosition()
    {
        // Crea un raggio dalla posizione della camera alla posizione del mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Controlla se il raggio colpisce qualcosa sul layer specificato
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (prefabScelto == 0)
            {
                if(money > 4)
                {
                    // Instanzia il Caparezza alla posizione colpita dal raggio
                    Instantiate(Caparezza, hit.point + new Vector3(0, 2, 0), rotation);
                    money -= 5;
                }
            } 
            else if (prefabScelto == 1)
            {
                if (money > 9)
                {
                    // Instanzia il Capaerzzino alla posizione colpita dal raggio
                    Instantiate(Caparezzino, hit.point + new Vector3(0, 2, 0), rotation);
                    money -= 10;
                }

            } 
            else if (prefabScelto == 2)
            {
                if (money > 19)
                {
                    // Instanzia il Caparezzino vero alla posizione colpita dal raggio
                    Instantiate(CaparezzinoVero, hit.point + new Vector3(0, 2, 0), rotation);
                    money -= 20;
                }

            } 
            else if (prefabScelto == 3)
            {
                if (money > 24)
                {
                    // Instanzia il Caparezzino vero alla posizione colpita dal raggio
                    Instantiate(Ilaria, hit.point + new Vector3(0, 2, 0), rotation);
                    money -= 25;
                }
            }
            else if (prefabScelto == 4)
            {
                if (money > 29)
                {
                    // Instanzia il Caparezzino vero alla posizione colpita dal raggio
                    Instantiate(Luigi, hit.point + new Vector3(0, 2, 0), rotation);
                    money -= 30;
                }
            }
            else if (prefabScelto == 5)
            {
                if (money > 39)
                {
                    // Instanzia il Caparezzino vero alla posizione colpita dal raggio
                    Instantiate(Bonobbo, hit.point + new Vector3(0, 2, 0), rotation);
                    money -= 40;
                }
            }
        }
    }

    public void StartRound()
    {
        StartCoroutine(tdspawner.spawn());
        Win.SetActive(false);
    }

    public void Caparezza_button()
    {
        prefabScelto = 0;
    }

    public void Caparezzino_button()
    {
        prefabScelto = 1;
    }

    public void CaparezzinoVero_button()
    {
        prefabScelto = 2;
    }

    public void Ilaria_button()
    {
        prefabScelto = 3;
    }

    public void Luigi_button()
    {
        prefabScelto = 4;
    }

    public void bonobo_button()
    {
        prefabScelto = 5;
    }
}
