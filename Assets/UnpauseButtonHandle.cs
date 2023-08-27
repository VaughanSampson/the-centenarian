using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpauseButtonHandle : MonoBehaviour
{
    public void Unpause()
    {
        print("s");
        GameController.instance.TogglePause();
    }
}
