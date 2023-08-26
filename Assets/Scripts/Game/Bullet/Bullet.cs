using System;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] protected float speed = 100.0f;
    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private GameObject hitEffect;

    public void Initiate(Vector2 shooterVelocity)
    {
        rigidBody.AddForce(transform.up * speed + (Vector3)shooterVelocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Bullet" || collision.tag == "Uranium Collectable") return;
        Instantiate(hitEffect, transform.position, transform.rotation);
        
        Destroy(this.gameObject);
    }

    private void OnBecameInvisible()
    {
        if (this.enabled)
        {
            Destroy(this.gameObject);
        }

    }
}
