using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class WaveData : MonoBehaviour
{
    [SerializeField] UpgradesManager upgradesManager;
    [Header("AreaSettings")]
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [SerializeField] Wave[] waves;
    public int nextWave = 0;
    private Wave currentWave;

    [SerializeField] private float warningTime = 1.5f;
    [SerializeField] private GameObject WarningEnemy;
    [SerializeField] private GameObject WarningBoss;

    private enum SpawnState { Spawning, Waiting, Counting }
    private SpawnState state = SpawnState.Counting;
    [SerializeField] private float timeBetweenEnemies = 3f;

    public UnityEvent CompleteLevel;
    public UnityEvent Finish;

    private void Start()
    {
        currentWave = waves[0];
    }


    public void WaveChange()
    {
        nextWave++;
        upgradesManager.SuggestUpgrade();
        currentWave = waves[nextWave];
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
            upgradesManager.SuggestUpgrade();
            AudioManager.Instance.PlaySFX("UpgradeUnavailable");
            currentWave = waves[nextWave];
        }
    }

    private bool EnemyIsAlive()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && GameObject.FindGameObjectsWithTag("Warning").Length == 0)
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

    IEnumerator SpawnEnemy()
    {
        Vector2 spawnArea = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        int rnd = Random.Range(0, currentWave.EnemiesInWave.Length);
        
        if (currentWave.isWaveBoss == false)
        {
            GameObject warning = Instantiate(WarningEnemy, spawnArea, Quaternion.identity);
            yield return new WaitForSeconds(warningTime);
            Destroy(warning);
        }
       else
        {

            GameObject warningBoss = Instantiate(WarningBoss, spawnArea, Quaternion.identity);
            yield return new WaitForSeconds(warningTime);
            Destroy(warningBoss);
        }        
        GameObject enemyToSpawn = currentWave.EnemiesInWave[rnd];
        Instantiate(enemyToSpawn, spawnArea, Quaternion.identity);
    }
    private void SpawnEnemies(Wave currentWave)
    {
        for (int i = 0; i < currentWave.WaveLevel + 1; i++)
        {
            StartCoroutine(SpawnEnemy());

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

        public bool isWaveBoss;
    }
}
