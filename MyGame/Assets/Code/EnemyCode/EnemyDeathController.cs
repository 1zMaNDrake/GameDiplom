using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathController : MonoBehaviour
{
    public void DestroyEnemy(float delay)
    {
        Destroy(gameObject, delay);
        Debug.Log(gameObject + "Умер!");
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
