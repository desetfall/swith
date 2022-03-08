using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;
    private Player player;
    private SpriteRenderer spriteRenderer;
    private const string RUN_ANIMATOR_KEY = "Running",
        JUMPSTART_ANIMATOR_KEY = "JumpStart",
        JUMPEND_ANIMATOR_KEY = "JumpEnd";

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        player = gameObject.GetComponent<Player>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (player.IsLeftBtnPressed || player.IsRightBtnPressed)
        {
            spriteRenderer.flipX = player.IsLeftBtnPressed ? true : false;
            animator.SetBool(RUN_ANIMATOR_KEY, true);           
        }
        else
        {
            animator.SetBool(RUN_ANIMATOR_KEY, false);
            spriteRenderer.flipX = false;
        }
    }

    public void PlayerJumpAnim()
    {
        if (player.IsGrounded)
        {
            animator.SetTrigger(JUMPSTART_ANIMATOR_KEY);
            StartCoroutine(PlayerEndJumpAnim());
        }
    }

    IEnumerator PlayerEndJumpAnim()
    {
        yield return new WaitUntil(() => !player.IsGrounded);
        yield return new WaitUntil(() => player.IsGrounded);
        animator.SetTrigger(JUMPEND_ANIMATOR_KEY);
    }

    public void PlayerDeadAnim()
    {
        Debug.Log("Анимация смерти");
    }
}
