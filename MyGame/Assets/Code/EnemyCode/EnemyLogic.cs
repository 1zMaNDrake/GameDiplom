using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyLogic : MonoBehaviour
{
    [SerializeField] private float speed = 3;

    Transform targetPlayer;

    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

  
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);

        Vector3 difference = (targetPlayer.position - transform.position).normalized;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + -90f);
    }
}
