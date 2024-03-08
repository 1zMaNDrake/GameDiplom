using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private Transform shotPoint;

    public Upgrades upgrade;

    private GameObject bullet;
    private float timeBtwShots;
    private float startTimeBtwShots;


    private void Update()
    {
        ChangeWeapon();
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots <= 0)
        {
            if (Input.GetKey(KeyCode.C))
            {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
            
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void ChangeWeapon()
    {
        startTimeBtwShots = upgrade.rechargeBullet;
        bullet = upgrade.updatePrefab;
    }

}