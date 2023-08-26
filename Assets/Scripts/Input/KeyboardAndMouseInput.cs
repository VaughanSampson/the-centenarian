using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardAndMouseInput : MonoBehaviour
{
    public static event Action fire;
    public static event Action<bool> accelerate;
    public static Vector2 mouseScreenPosition;
    public static Vector2 mouseWorldPosition;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.e))
            fire?.Invoke();

        mouseScreenPosition = Input.mousePosition;
        Debug.Log("Mouse Position: " + mousePosition);

        Accelerator();
    }

    float Accelerator(){

        if (Input.GetKeyDown(KeyCode.Space))
        {
            accelerate?.Invoke(true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            accelerate?.Invoke(false);

        }

    }
}
