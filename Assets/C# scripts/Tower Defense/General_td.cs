using UnityEngine;
using System.Collections;

public class General_td : MonoBehaviour
{
    public float shoot_time;
    
    public int BulletPower = 0;

    public GameObject bullet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(shoot());
        }
    }

    IEnumerator shoot()
    {
           GameObject bulletIstance = Instantiate(bullet, transform.position, transform.rotation);
           bulletIstance.GetComponent<Rigidbody>().AddForce(transform.forward * BulletPower, ForceMode.Impulse);
           Destroy(bulletIstance, 5f);
           yield return new WaitForSeconds(shoot_time);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
