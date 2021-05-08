using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct EntityWithProbability {
        public GameObject entity;
        public float probability;
    }
    
    public GameObject[] spawnPoints;
    public List<EntityWithProbability> availableEntities;
    public Transform entityToFollow;

    // Waves related stuff

    public int numberOfWaves = 1;
    public int currentWaveCount = 0;
    public float timeBetweenWaves = 5f;
    public List<GameObject> remainingEntities;

    private ZombieAI ai;

    private bool hasEveryoneSpawned = false; // Not used now, will be used when enemies will not spawn at the same time
    private float cumulProb = 0;

    public GameObject UI3DManagerObj;
    private UI3DManager UI3DManager;

    void Start()
    {
        remainingEntities = new List<GameObject>();
        UI3DManager = UI3DManagerObj.GetComponent<UI3DManager>();

        availableEntities.Sort(delegate(EntityWithProbability x, EntityWithProbability y) {
            if (x.probability == y.probability) return 0;
            else if (x.probability > y.probability) return 1;
            else if (x.probability < y.probability) return -1;

            return 0;
        });

        foreach (EntityWithProbability entity in availableEntities) {
            cumulProb += entity.probability;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UI3DManager.playButton.gameRunning) {
            remainingEntities.RemoveAll((GameObject entity) => entity == null);

            if (remainingEntities.Count == 0) { // When there's no more enemies to kill spawn another wave of zombies
                currentWaveCount++;
                StartCoroutine(SpawnZombies(currentWaveCount));
            }
        }
    }

    IEnumerator SpawnZombies(int currentWave) {
        int numBerOfEntitiesToSpawn = currentWaveCount * 50 * Random.Range(1, 3);

        for(int i = 0; i < numBerOfEntitiesToSpawn; i++) {
            float randomProbability = Random.Range(0, cumulProb); // Random float

            int index = 0;
            int entityIndex = -1;
            while (entityIndex == -1 && index < availableEntities.Count) {
                if (randomProbability < availableEntities[index].probability) {
                    entityIndex = index;
                }

                randomProbability -= availableEntities[index].probability;
                index++;
            }
            Vector3 position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            Vector3 spawnPlace = new Vector3(position.x, 0, position.z);
            GameObject currentEntity = Instantiate(availableEntities[entityIndex].entity, spawnPlace, Quaternion.identity);
            currentEntity.GetComponent<ZombieAI>().setTarget(entityToFollow); // Assigning the player as the target for the zombie
            remainingEntities.Add(currentEntity); // Adding the spawned zombie to the remaining entities
            yield return new WaitForSeconds (0.5f);
        }
    }   
}
