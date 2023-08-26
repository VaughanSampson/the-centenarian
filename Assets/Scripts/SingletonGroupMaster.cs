using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGroupMaster : MonoBehaviour
{
    private static SingletonGroupMaster masterInstance;

    // Start is called before the first frame update
    void Start()
    {
        if (masterInstance) Destroy(gameObject);

        masterInstance = this;

        DontDestroyOnLoad(gameObject);
    }

}
