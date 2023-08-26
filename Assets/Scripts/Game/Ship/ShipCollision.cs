using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : MonoBehaviour
{
    [SerializeField] private ShipWreckage wreckage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet") return;
            Explode();
    }

    public void Explode()
    {
        wreckage = Instantiate(wreckage, transform.position, transform.rotation);
        wreckage.Init();
        Destroy(this.gameObject);
    }

   
    
}
