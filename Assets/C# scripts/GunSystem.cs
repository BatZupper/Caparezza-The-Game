using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    //animator
    public Animator animator;

    //audio
    public AudioSource audioSource;

    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    public GameObject bulletHoleGraphic;
    public TextMeshProUGUI text;

    //punteggi
    public int Matrimoni_salvati = 0;
    public int Best_matrimoni = 0;

    private void Awake()
    {
        Best_matrimoni = PlayerPrefs.GetInt("MatrimoniSalvatiBest");
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        if (Matrimoni_salvati > Best_matrimoni)
        {
            PlayerPrefs.SetInt("MatrimoniSalvatiBest", Matrimoni_salvati);
            Best_matrimoni = Matrimoni_salvati;
        }

        MyInput();

        //SetText
        text.SetText(bulletsLeft + "/" + magazineSize);
    }
    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0){
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        //animazioni e merda simile
        animator.SetBool("shoot", true);
        audioSource.Play();

        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy"))
            {
                rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);
            }
            else if (rayHit.collider.CompareTag("DjStation"))
            {
                rayHit.collider.GetComponent<DjStation>().DestroyStation();
                Matrimoni_salvati++;
            }
            else if (rayHit.collider.CompareTag("DjStation_main"))
            {
                rayHit.collider.GetComponent<DjStation_main>().DestroyStation();
                Matrimoni_salvati++;
            }
            else if (rayHit.collider.CompareTag("DJ"))
            {
                rayHit.collider.GetComponent<Main_DJ>().DestroyDJ();
                Matrimoni_salvati++;
            }

        }

        //Graphics
        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsShot > 0 && bulletsLeft > 0)
        Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        animator.SetBool("shoot", false);
        readyToShoot = true;
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
