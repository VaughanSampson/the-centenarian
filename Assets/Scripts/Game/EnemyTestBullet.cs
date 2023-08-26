using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestxBullet : MonoBehaviour
{
    public Bullet BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bullet bullet = Instantiate(BulletPrefab, this.transform.position, this.transform.rotation);
            bullet.Initiate();
        }
    }
}
