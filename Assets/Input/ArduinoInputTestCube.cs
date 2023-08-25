
using System;
using UnityEngine;

public class ArduinoInputTestCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ArduinoInput.GetSingleInput += SetY;
    }

    public void SetY(int y) {
        transform.position = new Vector3(0, y/60, 0);
    }

}
