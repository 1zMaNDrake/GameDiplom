using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyLogic : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private float shootingRange;
    [SerializeField] private GameObject bullet;
    private Transform targetPlayer;

    private float fireRate = 1.5f;
    private float nextShootTime;

    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 difference = (targetPlayer.position - transform.position).normalized;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + -90f);

        float distanceFromPlayer = Vector2.Distance(targetPlayer.position, transform.position);
        if (distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && nextShootTime < Time.time)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            nextShootTime = Time.time + fireRate;
        }
    }
}
