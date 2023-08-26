using System.Collections;
using System;
using UnityEngine;

public class MainCoroutine : MonoBehaviour
{
    public static event Action<float> OnMainUpdate;
    private float updateTimer = 0.05f;

    void Awake()
    {
        StartCoroutine("MainUpdate");
    }

    IEnumerator MainUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(updateTimer);
            OnMainUpdate?.Invoke(updateTimer);
        }
    }
}
