using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private GameObject rocket;


    [SerializeField] private float SpawnTimer;
    private float timeBtwShots;
    private float startTimeBtwShots = 0.45f;

    public void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + -90f);

            if (timeBtwShots <= 0)
            {
                float randomValue = Random.value;
                if (randomValue <= 0.15f)
                {
                    Instantiate(rocket, transform.position, transform.rotation);
                }
                timeBtwShots = startTimeBtwShots;
            }

            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        
    }
}
