using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealsSpawn : MonoBehaviour
{
    [SerializeField] private float SpawnTimer;
    private float Timer;
    [SerializeField] private float SpawnChance = 0.5f;
    [SerializeField] private GameObject Heals;

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= SpawnTimer)
        {
            SpawnHeal();
            Timer = 0;
        }
    }

    private void SpawnHeal()
    { 
            float randomValue = Random.value;
            Vector2 spawnArea = new(Random.Range(-23f, 23f), Random.Range(-10f, 13f));
            GameObject HealToSpawn = Heals;
            if (randomValue <= SpawnChance)
            {
               Instantiate(HealToSpawn, spawnArea, Quaternion.identity);
            }
    }   
}
