using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAi : MonoBehaviour
{
    public float healt = 100;
    public int damage = 10;

    [SerializeField] PlayerManager PlayerManager;

    // Update is called once per frame
    void Update()
    {
        //se non hai vita esplodi
        if(healt <= 0)
        {
            Destroy(gameObject);
        }
    }

    //se ti sparano, fatti male
    public void TakeDamage(float damage)
    {
        healt -= damage;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerManager.health -= damage;
        }
    }
}
