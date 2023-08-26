using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UraniumNode : Asteroid
{

    [SerializeField] private UraniumCollectable collectable;
    private int averageDropCount = 6;

    private int health = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            health--;
            if (health <= 0)
                Explode();
        }
    }

    public void Explode()
    {
        for(int i = 0; i < averageDropCount; i++)
        {
            UraniumCollectable c = Instantiate(collectable, transform.position, Quaternion.identity);
            c.Init();
        }
        Destroy(this.gameObject);
    }
}
