using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealsSpawn : MonoBehaviour
{
    [SerializeField] private float SpawnTimer;
    private float Timer;
    [SerializeField] private float SpawnChance = 0.5f;
    [SerializeField] private GameObject WarningHeal;
    [SerializeField] private GameObject Heals;

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= SpawnTimer)
        {
            StartCoroutine(HealSpawnChance());
            Timer = 0;
        }
    }

    IEnumerator HealSpawnChance()
    {
        float randomValue = Random.value;
        Vector2 spawnArea = new(Random.Range(-23f, 23f), Random.Range(-10f, 13f));
        GameObject HealToSpawn = Heals;
        if (randomValue <= SpawnChance)
        {
            GameObject warning = Instantiate(WarningHeal, spawnArea, Quaternion.identity);
            yield return new WaitForSeconds(2f);
            Destroy(warning);
            Instantiate(HealToSpawn, spawnArea, Quaternion.identity);
        }
    }
}
