using UnityEngine;

public class TDBullet : MonoBehaviour
{
    [SerializeField] TD_Manager td_manager;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Enemy"))
        {
            td_manager.money++;

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
