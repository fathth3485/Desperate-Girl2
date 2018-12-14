using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    float maxSpawnRateInSeconds = 2;

    // Use this for initialization
    void Start()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        InvokeRepeating("IncreaseSpawnRate", 0, 30);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject anEnemy = (GameObject)Instantiate(Enemy);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        ScheduleNextEnemySpawn();

        void ScheduleNextEnemySpawn()
        {
            float spawnInSeconds;
            if (maxSpawnRateInSeconds > 1)
            {
                spawnInSeconds = Random.Range(1, maxSpawnRateInSeconds);
            }
            else
                spawnInSeconds = 1;
            Invoke("SpawnEnemy", spawnInSeconds);
        }
        void IncreaseSpawnRate()
        {
            if (maxSpawnRateInSeconds > 1)
                maxSpawnRateInSeconds--;

            if (maxSpawnRateInSeconds == 1)
                CancelInvoke("IncreaseSpawnRate");

        }



    }
}
