using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestxBullet : MonoBehaviour
{
    public Bullet BulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Bullet bullet = Instantiate(BulletPrefab, this.transform.position, this.transform.rotation);
            //bullet.Initiate();
        }
    }
}
