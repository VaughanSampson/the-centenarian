using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKeyboard : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5.0f;

    void Start()
    {
        KeyboardAndMouseInput.accelerate += Accelerate;
        KeyboardAndMouseInput.turn += Turn;

    }

    void Accelerate()
    {
        rigid.AddForce(new Vector3(0, 0, ));
        transform.Rotate(Vector3.up, rotationAmount);
    }

    private void OnDestroy()
    {
        MovementController.OnMove -= HandleMove;
    }
}
