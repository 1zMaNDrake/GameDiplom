using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawAttack : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerPhysics>())
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();

            healthController.TakeDamage(_damageAmount);

        }
    }
}
