using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{

    [SerializeField] private float timeBetweenWaves = 3f;
    [SerializeField] private float enemyMult;


    [Header("Components")]

    [SerializeField] private GameObject[] enemyPrefabs;
    private Vector2 spawnArea;


    [Header("Debug")]

    public int waveCount = 0;
    [SerializeField] private float checkIntervals = 2;


    public void Start()
    {
        waveCount += 1;
       
        StartCoroutine(SpawnWave());

    }

    public UnityEvent CompleteLevel;
    public UnityEvent Finish;



    IEnumerator SpawnWave() {

        while (true)
        {

            yield return new WaitForSeconds(checkIntervals); 

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            

            if (enemies.Length == 0)
            {
                if (waveCount == 3)
                {
                    CompleteLevel.Invoke();
                    
                }
                yield return new WaitForSeconds(timeBetweenWaves);
                if (waveCount == 6)
                {
                    StopAllCoroutines();
                    Finish.Invoke();
                    break;
                }
                SpawnEnemies();
            }

        }

    }

    private void SpawnEnemies() {

        for (int i = 0; i < waveCount * enemyMult; i++)
        {
            spawnArea = new Vector2(Random.Range(-23f, 23f), Random.Range(-12f, 12f));
            int rnd = Random.Range(0, enemyPrefabs.Length);

            GameObject enemyToSpawn = enemyPrefabs[rnd];

            Instantiate(enemyToSpawn, spawnArea, Quaternion.identity);

        }
        waveCount++;

    }

}
