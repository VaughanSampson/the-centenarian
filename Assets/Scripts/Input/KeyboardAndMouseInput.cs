using System;
using UnityEngine;

public class KeyboardAndMouseInput : MonoBehaviour
{
    public static event Action<bool> Trigger;
    public static event Action<bool> Accelerate;
    public static Vector2 MouseScreenPosition;
    public static Vector2 MouseWorldPosition;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            Trigger?.Invoke(true);
        else
        if (Input.GetKeyUp(KeyCode.E))
            Trigger?.Invoke(false);

        MouseScreenPosition = Input.mousePosition;
        MouseWorldPosition = Camera.main.ScreenToWorldPoint(MouseScreenPosition);

        GetAccelerate();
    }

    void GetAccelerate(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Accelerate?.Invoke(true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Accelerate?.Invoke(false);

        }
    }
}
