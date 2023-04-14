using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    float spawnRange = 9f;
    public GameObject enemyPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefabs, RandomSpawn(), transform.rotation);
    }

    private Vector3 RandomSpawn()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(x: spawnPosX, 0, spawnPosZ);

        return randomPos;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
