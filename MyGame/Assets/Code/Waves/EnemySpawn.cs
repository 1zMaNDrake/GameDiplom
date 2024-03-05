using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1.5f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int countEnemy;
    [SerializeField] private int maxEnemyOnScreen;

    public bool canSpawn;

    private Vector2 spawnArea;



    private void Start()
    {
        canSpawn = true;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (canSpawn && countEnemy > 0)
        {
          
            WaitForSeconds wait = new(spawnRate);
            yield return wait;

            spawnArea = new Vector2(Random.Range(-23f, 23f), Random.Range(-12f, 12f));
            int rnd = Random.Range(0, enemyPrefabs.Length);

            GameObject enemyToSpawn = enemyPrefabs[rnd];

            Instantiate(enemyToSpawn, spawnArea, Quaternion.identity);
            countEnemy--;
        }

    }
}
