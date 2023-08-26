using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGunShooter : MonoBehaviour
{
    public Bullet BulletPrefab;
    public Transform firePoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(shoot());
        }
    }

    IEnumerator shoot()
    {
        Bullet bullet = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        bullet.Initiate();
        yield return new WaitForSeconds(.5f);
    }
}
