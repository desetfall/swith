using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rb;
    private Transform tr;
    private PlayerMove playerMove;
    private SpriteRenderer spriteRenderer;
    private const string CAM_SWIPE_TRIGGER = "Swipe";
    [SerializeField]
    private Animator camAnimator;
    [SerializeField]
    private Color clrBlack, clrWhite;

    private void Start()
    {
        player = gameObject.GetComponent<Player>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerMove = gameObject.GetComponent<PlayerMove>();
        tr = transform;
    }

    public void SwitchButton()
    {
        if (player.IsGrounded)
        {
            Vector2 pos = new Vector2(tr.position.x, tr.position.y - (player.IsSwiped ? -0.58f : 0.58f));
            RaycastHit2D hit = Physics2D.Raycast(pos, (player.IsSwiped ? Vector2.up : -Vector2.up), 0.05f);
            Debug.Log(hit.collider.GetType());
            if (hit.collider is EdgeCollider2D)
            {
                Switch();
            }     
        }
    }

    public void Switch()
    {      
        player.IsSwiped = !player.IsSwiped;
        rb.simulated = false;
        rb.gravityScale *= -1;
        playerMove.SwipeSpeed();
        spriteRenderer.color = player.IsSwiped ? clrWhite : clrBlack;
        camAnimator.SetTrigger(CAM_SWIPE_TRIGGER);
        tr.rotation = Quaternion.Euler(0.0f, 0.0f, (player.IsSwiped ? 180.0f : 0.0f));
        Vector2 pos = new Vector2(tr.position.x, tr.position.y - (player.IsSwiped ? 0.58f : -0.58f));
        RaycastHit2D hit = Physics2D.Raycast(pos, (player.IsSwiped ? -Vector2.up : Vector2.up), 0.05f);
        tr.position = new Vector3(tr.position.x, hit.point.y - (player.IsSwiped ? 0.58f : -0.58f), tr.position.z);
        rb.simulated = true;
    }
}
