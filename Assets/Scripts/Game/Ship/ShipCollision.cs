using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : MonoBehaviour
{
    [SerializeField] private ShipWreckage wreckage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "UraniumCollectable")
        {
            GameController.instance.AddScore(Random.Range(5, 13));
            Destroy(collision.gameObject);
            return;
        }

        if (collision.tag == "Bullet" || collision.tag == "UraniumCollectable") return;
            Explode();
    }

    public void Explode()
    {
        wreckage = Instantiate(wreckage, transform.position, transform.rotation);
        wreckage.Init();
        GameController.instance.FinishGame();
        Destroy(this.gameObject);
    }

   
    
}
