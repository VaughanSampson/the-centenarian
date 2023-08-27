using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayButtonHandle : MonoBehaviour
{
    public void Replay()
    {
        GameController.instance.Reset();
    }
}
