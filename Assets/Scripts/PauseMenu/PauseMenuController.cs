using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenuController : MonoBehaviour
{
    public bool focus = true;
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    ArduinoInput dialinput = new ArduinoInput();
    private int index = 0;


    public void Init()
    {
        ArduinoInput.SendDial += ChangeButton;
        ArduinoInput.SendTrigger += Trigger;
    }

    private void OnDisable()
    {
        ArduinoInput.SendDial -= ChangeButton;
        ArduinoInput.SendTrigger -= Trigger;
    }


    public void ChangeButton(int dial)
    {
            if (dial > 530)
            {
                index = 0;
            }
            else
            {
                index = 1;
            }
    }

    public void Trigger(bool trigger)
    {
        
    }

}
