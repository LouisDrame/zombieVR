using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct EntityWithProbability {
        public GameObject entity;
        public int probability;
    }
    
    public GameObject[] spawnPoints;
    public GameObject[] availableEntities;
    public EntityWithProbability[] availableEntitiesBis;
    public Transform entityToFollow;

    // Waves related stuff

    public int numberOfWaves = 5;
    public int currentWaveCount = 0;
    public float timeBetweenWaves = 5f;
    public List<GameObject> remainingEntities;

    private ZombieAI ai;

    private bool hasEveryoneSpawned = false; // Not used now, will be used when enemies will not spawn at the same time

    void Start()
    {
        remainingEntities = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        remainingEntities.RemoveAll((GameObject entity) => entity == null);

        if (remainingEntities.Count == 0) { // WHen there's no more enemies to kill spawn another wave of zombies
            currentWaveCount++;
            StartCoroutine(SpawnZombies(currentWaveCount));
        }
    }

    IEnumerator SpawnZombies(int currentWave) {
        int numBerOfEntitiesToSpawn = currentWaveCount * 5 * Random.Range(1, 3);
        Debug.Log(numBerOfEntitiesToSpawn);
        // yield return new WaitForSeconds(timeBetweenWaves);
        for(int i = 0; i < numBerOfEntitiesToSpawn; i++) {
            int entityIndex = Random.Range(0, availableEntities.Length);
            GameObject currentEntity = Instantiate(availableEntities[entityIndex], spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
            currentEntity.GetComponent<ZombieAI>().setTarget(entityToFollow); // Assigning the player as the target for the zombie
            remainingEntities.Add(currentEntity); // Adding the spawned zombie to the remaining entities
            yield return new WaitForSeconds (0.5f);
        }
    }   
}
