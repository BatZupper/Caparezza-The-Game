using UnityEngine;

public class DjStation_main : MonoBehaviour
{
    public Renderer Self;

    public GameObject explosion;

    //sistema di distruzione
    public void DestroyStation()
    {
        Destroy(Self);
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
