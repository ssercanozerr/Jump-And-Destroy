using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public float speed = 1f;
    private bool isGoLeft = false;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float directionMovement = isGoLeft ? -1f : 1f;
        Vector2 newScale = transform.localScale;
        if (directionMovement > 0)
        {
            newScale.x = 0.6f;
        }
        if (directionMovement < 0)
        {
            newScale.x = -0.6f;
        }
        transform.localScale = newScale;
        transform.Translate(Vector3.right * directionMovement * speed * Time.deltaTime);

        if (transform.position.x <= startPosition.x - 0.8f || transform.position.x >= startPosition.x + 0.8f)
        {
            isGoLeft = !isGoLeft;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameSceneUIScript.score += 5;
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(2);
        }
    }
}
