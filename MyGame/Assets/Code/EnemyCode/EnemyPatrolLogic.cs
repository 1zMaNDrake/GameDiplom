using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolLogic : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float waitTime;
    [SerializeField] private float startWaitTime;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    private Vector2 moveSpot;

    void Start()
    {
       
        waitTime = startWaitTime;

        moveSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
