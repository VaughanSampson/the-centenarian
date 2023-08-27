using UnityEngine;
using UnityEngine.UI;

public class ArduinoMenuButton: MonoBehaviour
{
    [SerializeField] private Image outline;
    [SerializeField] private Button button;

    public void SetSelected(bool selected)
    {
        outline.enabled = selected;
    }

    public void Call()
    {
        button.onClick.Invoke();
    }
}
