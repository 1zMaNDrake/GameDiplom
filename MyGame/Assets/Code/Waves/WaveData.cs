using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class WaveData : MonoBehaviour
{

    public Wave[] waves;
    public int nextWave = 0;
    private Wave currentWave;

    private enum SpawnState { Spawning, Waiting, Counting }
    private SpawnState state = SpawnState.Counting;
    [SerializeField] private float timeBetweenEnemies = 3f;

    public UnityEvent CompleteLevel;
    public UnityEvent Finish;

    private void Start()
    {
        currentWave = waves[0];
    }


    private void Update()
    {

        if (state == SpawnState.Waiting) 
        {
            if (EnemyIsAlive())
            {
                return;
            }
            if (currentWave.TimeOfWave <= 0)
            {
                currentWave.TimeOfWave = 0;
                
                StartCoroutine(WaveCompleted());
            }
        }
        if (state != SpawnState.Spawning && currentWave.TimeOfWave > 0)
        {
            StartCoroutine(SpawnWave(currentWave));
        }
        currentWave.TimeOfWave -= Time.deltaTime;
    }

    IEnumerator WaveCompleted()
    {
        state = SpawnState.Counting;
        if (nextWave + 1 > waves.Length - 1)
        {
            yield return new WaitForSeconds(3);
            Finish.Invoke();
        }
        else
        {
            yield return new WaitForSeconds(3);
            nextWave++;
            CompleteLevel.Invoke();
            currentWave = waves[nextWave];
        }
    }

    private bool EnemyIsAlive()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            return false;
        }
        return true;
    }

    IEnumerator SpawnWave(Wave currentWave)
    {
        state = SpawnState.Spawning;
        yield return new WaitForSeconds(timeBetweenEnemies);
        SpawnEnemies(currentWave);
        state = SpawnState.Waiting;
    }

    private void SpawnEnemies(Wave currentWave)
    {
        for (int i = 0; i < currentWave.WaveLevel +1; i++)
        {
            Vector2 spawnArea = new Vector2(Random.Range(-23f, 23f), Random.Range(-10f, 13f));
            int rnd = Random.Range(0, currentWave.EnemiesInWave.Length);
            GameObject enemyToSpawn = currentWave.EnemiesInWave[rnd];
            Instantiate(enemyToSpawn, spawnArea, Quaternion.identity);
        }
        currentWave.WaveLevel++;
    }

    [System.Serializable]
    public class Wave
    {
        [Range(0, 360)]
        public float TimeOfWave;

        public GameObject[] EnemiesInWave;

        public int WaveLevel;

    }
}
