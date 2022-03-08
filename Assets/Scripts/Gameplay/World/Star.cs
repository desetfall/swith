using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;
        if (player.CompareTag(PLAYER_TAG))
        {
            player.GetComponent<Player>().TempStarsCount += 1;
            Destroy(gameObject);
        }
    }
}
