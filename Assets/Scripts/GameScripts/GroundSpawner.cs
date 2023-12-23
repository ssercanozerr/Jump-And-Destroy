using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject ground;
    public GameObject enemy;
    private int enemySpawnPosibility;
    Transform tr;
    public float groundWidth;
    public float miny, maxy;
    Vector3 spawnLocationGround = new Vector3();
    Vector3 spawnLocationEnemy = new Vector3();
    Vector2 newScale = new Vector2();
    void Start()
    {

        tr = ground.GetComponent<Transform>();

        for (int i = 0; i < 50; i++)
        {
            GroundSpawn();
        }
    }

    public void GroundSpawn()
    {
        newScale.x = Random.Range(1.9f, 2.1f);
        newScale.y = Random.Range(0.9f, 1.1f);
        tr.localScale = newScale;

        spawnLocationGround.x = Random.Range(-groundWidth, groundWidth);
        spawnLocationGround.y += Random.Range(miny, maxy);

        Instantiate(ground, spawnLocationGround, Quaternion.identity);

        spawnLocationEnemy = spawnLocationGround;
        spawnLocationEnemy.y += 1;
        
        enemySpawnPosibility = Random.Range(1, 5);
        if (enemySpawnPosibility == 1)
        {
            Instantiate(enemy, spawnLocationEnemy, Quaternion.identity);
        }
    }

}
