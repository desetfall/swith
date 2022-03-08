using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    private Transform tr;
    private const string PLAYER_TAG = "Player";

    void Start()
    {
        tr = transform;
    }

    private void FixedUpdate()
    {
        tr.Rotate(Vector3.back);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PLAYER_TAG))
        {
            collision.gameObject.GetComponent<Player>().PlayerDead();
        }
    }
}
