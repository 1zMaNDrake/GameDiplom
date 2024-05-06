using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private float _damageAmount;

    public LayerMask whatIsSolid;

   
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distance, whatIsSolid);
;       if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
 
                hitInfo.collider.GetComponent<HealthController>().TakeDamage(_damageAmount);
                Debug.Log("Враг получил " + _damageAmount + " Урона!");
                

            }
            Destroy(gameObject);
        }

        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }
}
