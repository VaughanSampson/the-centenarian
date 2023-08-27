using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPieces : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;

    public void Init()
    {
        rigidBody.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * 150f);
        transform.Rotate(0, 0, Random.Range(-20, 20f));
    }

}
