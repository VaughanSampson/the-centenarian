using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UraniumCollectable : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;

    public void Init()
    {
        rigidBody.AddForce(new Vector2(Random.Range(-1,1f),Random.Range(-1,1f)) * 50f);
        transform.Rotate(0, 0, Random.Range(0, 360f));
        transform.localScale *= Random.Range(0.9f, 1.3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            GameController.instance.AddScore(Random.Range(5,13));
            Destroy(this.gameObject);
        }
    }

}
