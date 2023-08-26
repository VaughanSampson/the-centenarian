using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    private ShipController shipController;

    public void Init(ShipController shipController)
    {
        this.shipController = shipController;
    }

    private void Update()
    {
        if(shipController)
            transform.position = shipController.transform.position + new Vector3(0, 0, -10);
    }
}