using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(2);
        }
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Ground")
        {
            Destroy(collision.gameObject);
        }
    }
}
