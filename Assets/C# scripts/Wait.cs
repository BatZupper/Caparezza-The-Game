using UnityEngine;
using System.Collections;

public class Wait : MonoBehaviour
{
    public GameObject image;
    public GameObject sssaasss;

    IEnumerator respawn(float time)
    {
        image.SetActive(true);
        sssaasss.SetActive(true);
        yield return new WaitForSeconds(time);
        image.SetActive(false);
        sssaasss.SetActive(false);
    }

    // Start is called before the first execution of Update after the MonoBehaviour is created
    public void wait(float tempo)
    {
        StartCoroutine(respawn(tempo));
    }

}
