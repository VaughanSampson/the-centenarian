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
        if(!ArduinoInput.IsDisabled)
            SetToArduinoInput();
        else
            SetToKeyboardInput();   
    }

    public void SetToArduinoInput()
    {
        KeyboardAndMouseInput.Accelerate -= KB_ReceiveIsAcceleration;
        KeyboardAndMouseInput.Trigger -= KB_ReceiveTrigger;
        MainCoroutine.OnMainUpdate -= KB_CalculateAndSendTurn;

        ArduinoInput.SendTrigger += Arduino_RecieveTrigger;
        ArduinoInput.SendUltrasound += Arduino_RecieveUltrasound;
        ArduinoInput.SendDial += Arduino_RecieveDial;
    }


    public void SetToKeyboardInput()
    {
        KeyboardAndMouseInput.Accelerate += KB_ReceiveIsAcceleration;
        KeyboardAndMouseInput.Trigger += KB_ReceiveTrigger;
        MainCoroutine.OnMainUpdate += KB_CalculateAndSendTurn;

        ArduinoInput.SendTrigger -= Arduino_RecieveTrigger;
        ArduinoInput.SendUltrasound -= Arduino_RecieveUltrasound;
        ArduinoInput.SendDial -= Arduino_RecieveDial;
    }

    private void OnDisable()
    {
        KeyboardAndMouseInput.Accelerate -= KB_ReceiveIsAcceleration;
        KeyboardAndMouseInput.Trigger -= KB_ReceiveTrigger;
        MainCoroutine.OnMainUpdate -= KB_CalculateAndSendTurn;

        ArduinoInput.SendTrigger -= Arduino_RecieveTrigger;
        ArduinoInput.SendUltrasound -= Arduino_RecieveUltrasound;
        ArduinoInput.SendDial -= Arduino_RecieveDial;

    }

    public event Action<float> SetAcceleration;
    public event Action<float> SetAngularAcceleration;
    public event Action<bool> SetTrigger;

    // Keyboard and Mouse Input

    public void KB_ReceiveIsAcceleration(bool isAccelerating)
    {
        if (!isAccelerating)
        {
            SetAcceleration?.Invoke(0);
            return;
        }

        SetAcceleration?.Invoke(1);
    }

    public void KB_ReceiveTrigger(bool down)
    {
        SetTrigger?.Invoke(down);
    }

    public void KB_CalculateAndSendTurn(float deltaTime)
    {
        var dir = (Vector3)KeyboardAndMouseInput.MouseWorldPosition - lookSensor.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        lookSensor.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
        float zDif = lookSensor.localEulerAngles.z;
        zDif -= 180; 
        SetAngularAcceleration?.Invoke(zDif * deltaTime);
    }

    // Arduino Input

    /// <summary>
    /// Gets Arduino ultrasound distance input.
    /// </summary>
    /// <param name="distance">Ultrasound measured distance.</param>
    public void Arduino_RecieveUltrasound(int distance)
    {
        if (distance > 10 ) return;

        SetAcceleration?.Invoke(100f/(MathF.Pow(distance+1,3f)));
    }

    /// <summary>
    /// Gets Arduino dial turn input.
    /// </summary>
    /// <param name="rotation"></param>
    public void Arduino_RecieveDial(int rotation)
    {
        if(rotation < 450)
        {
            SetAngularAcceleration?.Invoke((rotation-450f)/100f);

        }
        else
        if (rotation > 610)
        {
            SetAngularAcceleration?.Invoke((rotation - 610f)/100f);
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
