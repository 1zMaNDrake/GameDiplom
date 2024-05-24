using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathController : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle = default;

    public void DestroyEnemy(float delay)
    {
        Invoke("ParticlePlay", delay);
        Destroy(gameObject, delay);
        Debug.Log(gameObject + "Умер!");
    }

    private void ParticlePlay()
    {
        Instantiate(particle, transform.position, Quaternion.identity);
    }


    public void DestroyAllEnemy(float delay)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in taggedObjects)
        {
            Destroy(obj, delay);

        }
    }
}
