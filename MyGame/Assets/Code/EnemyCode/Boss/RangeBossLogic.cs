using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBossLogic : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float speedRamming = 10;
    [SerializeField] private float startTimeBtwShots = 0.5f;
    [SerializeField] private GameObject bullet;
    private Transform targetPlayer;

    private float timeForShooting = 5f;
    private float timeBtwShots;
   
    private enum BossState { Shooting, Waiting, Ramming }
    private BossState state = BossState.Shooting;

    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 difference = (targetPlayer.position - transform.position).normalized;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + -90f);

        if (state == BossState.Ramming)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speedRamming * Time.deltaTime);
        }

        if (state == BossState.Shooting)
        { 
            if (timeForShooting >= 0)
            {           
                transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
                if (timeBtwShots <= 0)
                {
                    Instantiate(bullet, transform.position, transform.rotation);
                    timeBtwShots = startTimeBtwShots;
                }
                else
                {
                    timeBtwShots -= Time.deltaTime;
                }
            }
            else if (timeForShooting <= 0)
            {
                StartCoroutine(Waiting());
                timeForShooting = 5f;
            }
            timeForShooting -= Time.deltaTime;
        }

        if (state == BossState.Waiting)
        {
            return;
        }
    }
    IEnumerator Waiting()
    {
        state = BossState.Waiting;
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Ramming());
    }

    IEnumerator Ramming()
    {
        state = BossState.Ramming;
        yield return new WaitForSeconds(2f);
        state = BossState.Shooting;
    }
}

