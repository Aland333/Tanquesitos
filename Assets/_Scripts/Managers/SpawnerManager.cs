using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyTanks());
    }

    IEnumerator SpawnEnemyTanks()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-49,49), 0,Random.Range(-49,49));
        Instantiate(enemy, randomSpawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(3);
        
        StartCoroutine(SpawnEnemyTanks());
    }
}
