using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages and processes input from keyboard, mouse and Arduino.
/// </summary>
public class ShipInput : MonoBehaviour
{
    private ShipController controller;

    /// <summary>
    /// Sets up ShipInput.
    /// </summary>
    /// <param name="controller">Master controller of ship.</param>
    public void Init(ShipController controller)
    {
        this.controller = controller;
    }

    public event Action<float> setAccelerate;
    public event Action<float> setTurn;
    public event Action trigger;

    /// <summary>
    /// Gets Arduino ultrasound distance input.
    /// </summary>
    /// <param name="distance">Ultrasound measured distance.</param>
    public void Arduino_RecieveUltrasound(int distance)
    {
        setAccelerate?.Invoke(distance);
    }

    /// <summary>
    /// Gets Arduino dial turn input.
    /// </summary>
    /// <param name="rotation"></param>
    public void Arduino_RecieveDial(float rotation)
    {
        setTurn?.Invoke(rotation);
    }

    /// <summary>
    /// Gets trigger from Arduino input.
    /// </summary>
    public void Arduino_RecieveTrigger()
    {
        trigger?.Invoke();
    }

}
