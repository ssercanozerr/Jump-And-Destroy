using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private float jumpPower;
    private bool isTouchGround = false;
    private int doubleJumpPossibility;
    Animator animator;
    private void Start()
    {
        animator= GetComponent<Animator>();
        doubleJumpPossibility = Random.Range(1, 11);
        if (doubleJumpPossibility == 1)
        {
            animator.SetBool("isDoubleJumpGround", true);
            jumpPower = 20f;
        }

        else
        {
            jumpPower = 15f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (collision.gameObject.tag == "Player")
            {
                Vector2 transientVariable = rb.velocity;
                transientVariable.y = jumpPower;
                rb.velocity = transientVariable;
                if (isTouchGround == false)
                {
                    GameSceneUIScript.score++;
                    isTouchGround = true;
                }
                animator.SetBool("isTouchGround", true);
                Destroy(gameObject, 2f);
            }
        }
    }
}
