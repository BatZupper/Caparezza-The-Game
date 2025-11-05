using UnityEngine;
using System.Collections;

public class TDSpawner : MonoBehaviour
{
    public int rounds = 0;
    public GameObject Enemy;

    [SerializeField] TD_Manager td_manager;

    public IEnumerator spawn()
    {
        rounds++;

        for (int steps = 0; steps < 3 + rounds * 2; steps++)
        {
            GameObject enemyIstance = Instantiate(Enemy, transform.position, transform.rotation);
            enemyIstance.GetComponent<Rigidbody>().AddForce(transform.forward * (10 + rounds), ForceMode.Impulse);

            yield return new WaitForSeconds(3 - rounds /10);
        }

        td_manager.Win.SetActive(true);
        td_manager.money += 5 * rounds / 5;
    }
}
