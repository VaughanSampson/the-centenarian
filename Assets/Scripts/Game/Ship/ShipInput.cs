using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages and processes input from keyboard, mouse and Arduino.
/// </summary>
public class ShipInput : MonoBehaviour
{

    [SerializeField] private Transform lookSensor;

    /// <summary>
    /// Sets up ShipInput.
    /// </summary>
    /// <param name="controller">Master controller of ship.</param>
    public void Init(ShipController controller)
    {

        KeyboardAndMouseInput.Accelerate += KB_ReceiveIsAccelerating;
        KeyboardAndMouseInput.Trigger += KB_ReceiveTrigger;

        ArduinoInput.SendTrigger += Arduino_RecieveTrigger;
        ArduinoInput.SendUltrasound += Arduino_RecieveUltrasound;
        ArduinoInput.SendDial += Arduino_RecieveDial;

    }

    public event Action<float> SetAccelerate;
    public event Action<float> SetTurnAngle;
    public event Action<bool> SetTrigger;

    // Keyboard and Mouse Input

    public void KB_ReceiveIsAccelerating(bool a)
    {
        if (!a)
        {
            SetAccelerate?.Invoke(0);
        }
        else
        {
            SetAccelerate?.Invoke(1);
        }
            
    }

    public void KB_ReceiveTrigger(bool down)
    {
        SetTrigger?.Invoke(down);
    }

    public void KB_CalculateAndSendTurn()
    {

        SetTurnAngle?.Invoke(0);
    }


    // Arduino Input

    /// <summary>
    /// Gets Arduino ultrasound distance input.
    /// </summary>
    /// <param name="distance">Ultrasound measured distance.</param>
    public void Arduino_RecieveUltrasound(int distance)
    {
        if (distance > 10 ) return;

        SetAccelerate?.Invoke(11f/(distance+1)/300f);
    }

    /// <summary>
    /// Gets Arduino dial turn input.
    /// </summary>
    /// <param name="rotation"></param>
    public void Arduino_RecieveDial(int rotation)
    {
        if(rotation < 450)
        {
            SetTurnAngle?.Invoke(rotation-450);

        }
        else
        if (rotation > 610)
        {
            SetTurnAngle?.Invoke(rotation - 610);
        }
    }

    /// <summary>
    /// Gets trigger from Arduino input.
    /// </summary>
    public void Arduino_RecieveTrigger(bool down)
    {
        SetTrigger?.Invoke(down);
    }

}
