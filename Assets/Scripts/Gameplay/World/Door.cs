using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    private Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(PLAYER_TAG))
        {
            player = collision.gameObject.GetComponent<Player>();
            UpdateStartsCount();
            player.EndGame();
        }
    }

    private void UpdateStartsCount()
    {
        int starsCountAtTheEnd = player.TempStarsCount + 1;
        if (player.GetComponent<Player>().GetCurrentLevel.StarsCount < starsCountAtTheEnd)
        {
            player.GetComponent<Player>().GetCurrentLevel.StarsCount = starsCountAtTheEnd;
        }
    }
}
