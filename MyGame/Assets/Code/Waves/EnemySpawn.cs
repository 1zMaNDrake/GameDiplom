using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] public static bool canSpawn = true;

    public int spawnCount = 0;
    
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds wait = new(spawnRate);
        while (canSpawn == true)
        {
            yield return wait;

            int rnd = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rnd];


            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);

            Debug.Log(enemyPrefabs[rnd] +  "Заспавнен!");

            Debug.Log(spawnCount);

            spawnCount = spawnCount + 1;

            if (spawnCount >= 4)
            {
                canSpawn = false;

            }

        }
    }

}
