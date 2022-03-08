using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed, jumpForce;

    private const float MOVE_SPEED = 3.0f;

    private Rigidbody2D rb;

    private Vector2 direction, jumpVector;

    private Player player;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = gameObject.GetComponent<Player>();
        direction = Vector2.zero;
        jumpVector = Vector2.up;
    }

    private void FixedUpdate()
    {
        /*/
        if (player.IsLeftBtnPressed)
        {
            // direction = new Vector2(-1 * moveSpeed, rb.velocity.y);
            moveSpeed = -1 * MOVE_SPEED;
        }
        else if (player.IsRightBtnPressed)
        {
            // direction = new Vector2(moveSpeed, rb.velocity.y);
            moveSpeed = MOVE_SPEED;
        }
        else
        {
            // direction = new Vector2(0, rb.velocity.y);
            moveSpeed = 0.0f;
        }
       // rb.velocity = direction;
        /*/
        moveSpeed = player.IsLeftBtnPressed ? -1 * MOVE_SPEED : player.IsRightBtnPressed ? moveSpeed = MOVE_SPEED : 0.0f;
        rb.transform.Translate(moveSpeed * Time.fixedDeltaTime, 0, 0);
    }

    public void PlayerJump()
    {
        if (player.IsGrounded)
        {
            rb.AddForce(jumpVector * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void SwipeSpeed()
    {
        moveSpeed *= -1;
        jumpForce *= -1;
    }
}
