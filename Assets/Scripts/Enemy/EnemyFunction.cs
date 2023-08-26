using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFunction : MonoBehaviour
{
    private ShipController Player;

    [SerializeField] private Rigidbody2D rigidBody;


    public void Init(ShipController Player)
    {
        ;
    }

    private void Move()
    {
        transform.LookAt(Player.transform.position);
        rigidBody.AddForce(100 * transform.up);
    }

    void OncollisionEnter(Collision other)
    {
        Debug.Log("An enemy is destroyed.");
        Destroy(other.gameObject);
    }
}
