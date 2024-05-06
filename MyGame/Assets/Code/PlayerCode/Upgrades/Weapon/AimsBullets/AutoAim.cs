using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            transform.Translate(speed * Time.deltaTime * Vector2.up);
        }
        else
        {
            
            foreach (var enemy in enemies)
            {
                transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);

            }
        }
    }
}
