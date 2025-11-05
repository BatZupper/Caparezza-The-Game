using UnityEngine;

public class Main_DJ : MonoBehaviour
{
    int health = 1;

    GameObject player;

    [SerializeField] PlayerManager playermanager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("player");
        Destroy(gameObject, 90);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.1f);
        transform.LookAt(player.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playermanager.health -= 100;
        }
    }

    public void DestroyDJ()
    {
        Destroy(gameObject);
    }
}
