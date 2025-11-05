using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNellamappa : MonoBehaviour
{

    public GameObject player;

    float player_x = 0;
    float player_y = 0;

    RectTransform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<RectTransform>();
    }

    // DA FARE SISTEMARE LA MAPPA
    void Update()
    {
        player_x = player.transform.position.x * -1;
        player_y = player.transform.position.z * -1;

        transform.anchoredPosition = new Vector2(player_x, player_y);
    }
}
