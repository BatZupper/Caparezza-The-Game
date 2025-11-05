using UnityEngine;
using System.Collections;

public class Main_DJGenarator : MonoBehaviour
{

    public GameObject DJ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnDJ());
    }

    IEnumerator spawnDJ()
    {
        while (true) 
        {
            Instantiate(DJ, transform.position + Random.onUnitSphere * 150, transform.rotation);
            yield return new WaitForSeconds(Random.Range(3,5));
        }
    }
}
