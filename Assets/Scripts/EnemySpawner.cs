using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int maxEnemies = 5;

    // Spawn rate per seconds
    public float spawnRate = 8f;

    // Variable to set next spawn time
    float nextSpawn = 5f;

    // Variable with random values
    Vector3 spawnPos;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length >= maxEnemies)
            {
                Random.InitState(System.DateTime.Now.Millisecond);
                spawnPos = Random.onUnitSphere + transform.position;
                Instantiate(enemy, spawnPos, Quaternion.LookRotation(transform.position));
                Debug.Log("Enemy spawned");
            }
            // Set the next spawn time
            nextSpawn = Time.time + spawnRate;
        }
    }
}
