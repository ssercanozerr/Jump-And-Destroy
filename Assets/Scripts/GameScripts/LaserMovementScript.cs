using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovementScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    private PlayerBehaviourScript playerBehaviourScript;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerBehaviourScript = FindObjectOfType<PlayerBehaviourScript>();
        if (playerBehaviourScript.isTurnLeft)
        {
            rb.velocity = -transform.right * speed * Time.deltaTime;
        }
        else
        {
            rb.velocity = transform.right * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LaserDestroyWall" || collision.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }
    }
}
