using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void Start()
    {
        transform.Rotate(0, 0, Random.Range(0, Random.Range(0, 3) * 90));
    }
}
