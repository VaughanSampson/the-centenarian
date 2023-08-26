using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    [SerializeField] private float time;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", time);
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
