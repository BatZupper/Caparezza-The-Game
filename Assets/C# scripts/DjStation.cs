using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DjStation : MonoBehaviour
{
    bool isTimerZero = false;
    bool isDestroyed = false;

    public float timer = 120;

    public Renderer Self;

    public TextMeshProUGUI text;

    public AudioSource musica;

    public GameObject explosion;

    [SerializeField] PlayerManager PlayerManager;

    //avvia un timer che fa rinascere la postazione
    IEnumerator respawn(int a, int b)
    {
        text.SetText("Respawing...");
        yield return new WaitForSeconds(UnityEngine.Random.Range(a, b));
        timer = UnityEngine.Random.Range(160,320);
        isDestroyed = false;
        isTimerZero = false;
        Self.enabled = true;
    }

    //sistema di distruzione
    public void DestroyStation()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Self.enabled = false;
        isDestroyed = true;
        StartCoroutine(respawn(60, 180));
    }

    void Start()
    {
        isDestroyed = true;
        isTimerZero = false;
        Self.enabled = false;
        StartCoroutine(respawn(0, 60));
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (timer <= 0)
        {
            isTimerZero = true;
        }

        if (isTimerZero == false && isDestroyed == false)
        {
            timer -= Time.deltaTime;
            timer = Mathf.Floor(timer * 10f) / 10f;

            text.SetText(timer.ToString());
        } else if (isTimerZero == true)
        {
            text.SetText("Attivato");
            musica.Play();
            PlayerManager.health -= 1;
        }
       
    }
}
