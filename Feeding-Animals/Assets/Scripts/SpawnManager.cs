using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20.0f;
    private float spawnRangeZTop = 13.0f;
    private float spawnRangeZBottom = 5.0f;
    private float spawnPosZ = 20.0f;
    private float spawnPosX = 26.0f;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;
    public float spawnDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(new Vector3(0, 180, 0)));
        Invoke("SpawnRandomAnimalSideWays", spawnDelay);
    }
    void SpawnRandomAnimalSideWays()
    {
        Vector3 spawnPos;
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int leftOrRight = Random.Range(0, 2); //0 - Left ; 1 - Right 
        if(leftOrRight == 0)
        {
            spawnPos = new Vector3(-spawnPosX, 0, Random.Range(spawnRangeZTop,spawnRangeZBottom));
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(new Vector3(0, 90, 0)));
        }
        else
        {
            spawnPos = new Vector3(spawnPosX, 0, Random.Range(spawnRangeZTop, spawnRangeZBottom));
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(new Vector3(0, -90, 0)));
        }
    }
}
