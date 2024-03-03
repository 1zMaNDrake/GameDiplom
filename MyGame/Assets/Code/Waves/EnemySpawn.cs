using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1.5f;
    [SerializeField] private int spawnWave = 5;
    [SerializeField] private GameObject[] enemyPrefabs;

    public bool canSpawn;

    public static int spawnCount = 0;


    public Vector2 spawnArea;

    private void Start()
    {
        canSpawn = true;
        StartCoroutine(Spawn());
    }
    private void Update()
    {
        if(spawnCount >= spawnWave)
        {
            canSpawn = false;
        }
        else
        {
            canSpawn = true;
        }
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds wait = new(spawnRate);
        while (canSpawn == true)
        {
            yield return wait;
            spawnArea = new Vector2(Random.Range(-18f, 18f), Random.Range(-8f, 8f));
            int rnd = Random.Range(0, enemyPrefabs.Length);;

            GameObject enemyToSpawn = enemyPrefabs[rnd];

            Instantiate(enemyToSpawn, spawnArea, Quaternion.identity);

            Debug.Log(enemyPrefabs[rnd] +  "Заспавнен!");
            Debug.Log(canSpawn);

            Debug.Log(spawnCount);

            spawnCount ++;

        }
    }

}
