using System;
using UnityEngine;

public class KeyboardAndMouseInput : MonoBehaviour
{
    public static event Action fire;
    public static event Action<bool> accelerate;
    public static Vector2 mouseScreenPosition;
    public static Vector2 mouseWorldPosition;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            fire?.Invoke();

        mouseScreenPosition = Input.mousePosition;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        Debug.Log("Mouse Position: " + mouseWorldPosition);

        Accelerator();
    }

    void Accelerator(){
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
