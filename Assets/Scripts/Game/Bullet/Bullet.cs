using System;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] protected float speed = 100.0f;
    [SerializeField] private Rigidbody2D rigidBody;

    public void Initiate(Vector2 shooterVelocity)
    {
        rigidBody.AddForce(transform.up * speed + (Vector3)shooterVelocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Enemy")
        {
            return; 
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        if (this.enabled)
        {
            Destroy(this.gameObject);
        }

    }
}
