using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] availableEntities;

    // Waves related stuff

    public int numberOfWaves = 5;
    public int currentWaveCount = 0;
    public List<GameObject> remainingEntities;

    void Start()
    {
        remainingEntities = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingEntities.Count == 0) {
            Debug.Log("Spawning Zombies");
            currentWaveCount++;
            SpawnZombies(currentWaveCount);
        }
    }

    void SpawnZombies(int currentWave) {
        for(int i = 0; i < spawnPoints.Length; i++) {
            int entityIndex = Random.Range(0, availableEntities.Length);
            GameObject currentEntity = Instantiate(availableEntities[entityIndex], spawnPoints[i].transform.position, Quaternion.identity);
            remainingEntities.Add(currentEntity);
            Debug.Log("Spawned");
        }
    }   
}
