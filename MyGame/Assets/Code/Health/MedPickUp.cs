using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedPickUp : MonoBehaviour
{
    [SerializeField] private float _healthAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerPhysics>())
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();

            healthController.AddHealth(_healthAmount);
            Destroy(this.gameObject);
        }

    }
}
