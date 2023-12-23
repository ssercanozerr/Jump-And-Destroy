using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed;
    private float horizontalMovement;
    public GroundSpawner groundSpawner;
    public bool isTurnLeft;
    public GameObject laser;
    public GameObject laserSpawner;
    AudioSource audioLaser;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioLaser= GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laser, laserSpawner.transform.position, laserSpawner.transform.rotation);
            audioLaser.Play();
        }     
    }

    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalMovement * movementSpeed * Time.deltaTime, rb.velocity.y);

        Vector2 newScale = transform.localScale;
        if (horizontalMovement > 0)
        {
            newScale.x = 0.35f;
            isTurnLeft = false;
        }
        if (horizontalMovement < 0)
        {
            newScale.x = -0.35f;
            isTurnLeft = true;
        }
        transform.localScale = newScale;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            groundSpawner.GroundSpawn();
        }
    }
}
