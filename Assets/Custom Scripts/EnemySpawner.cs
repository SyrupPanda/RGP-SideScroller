using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public float spawnRate;
    public int countToSpawn;

    private float time = 0;
    private int spawnCount = 0;

    public float minSpeed;
    public float maxSpeed;
    public float minOff;
    public float maxOff;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > spawnRate)
        {
            GameObject ship = Instantiate(enemyToSpawn, transform.position, transform.rotation);
            ship.GetComponent<RedPlagueMover>().vSpeed = Random.Range(minSpeed, maxSpeed);
            ship.GetComponent<RedPlagueMover>().maxXOffset = Random.Range(minOff, maxOff);

            time = 0;
            spawnCount++;
            if(spawnCount > countToSpawn)
            {
                time = 0;
            }
        }
    }
}
