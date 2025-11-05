using UnityEngine;
using TMPro;

public class TDMolfetta : MonoBehaviour
{
    public GameObject boom;

    public int health = 100;

    public TMP_Text salute;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(boom, other.transform.position, transform.rotation);
            Destroy(other.gameObject);
            health -= 1;
            salute.SetText(health.ToString());
        }

        if (health < 1)
        {
            Destroy(gameObject);
        }
    }
}
