using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCController : MonoBehaviour
{
    private Player player;
    private PlayerSwitch playerSwitch;
    private PlayerMove playerMove;

    private void Start()
    {
        player = gameObject.GetComponent<Player>();
        playerSwitch = gameObject.GetComponent<PlayerSwitch>();
        playerMove = gameObject.GetComponent<PlayerMove>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                player.IsLeftBtnPressed = true;
            }
            else
            {
                player.IsRightBtnPressed = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            player.IsRightBtnPressed = false;
            player.IsLeftBtnPressed = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerMove.PlayerJump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerSwitch.SwitchButton();
        }
    }
}
