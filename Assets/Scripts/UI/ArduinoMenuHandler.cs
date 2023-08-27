using UnityEngine;
using UnityEngine.UI;

public class ArduinoMenuHandler : MonoBehaviour
{

    [SerializeField] private ArduinoMenuButton[] buttons;

    private int index = 0;

    private void OnEnable()
    {
        Init();
    }

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

        for (int i = 0; i < buttons.Length; i++)
            buttons[i].SetSelected(i == index);
            
    }

    private bool lastTrigger = true;

    public void Trigger(bool trigger)
    {
        if (trigger && !lastTrigger)
            buttons[index].Call();
        lastTrigger = trigger;

    }
}
