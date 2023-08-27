using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWreckage : MonoBehaviour
{
    [SerializeField] private ShipPieces[] pieces;
    public void Init()
    {
        foreach (ShipPieces piece in pieces)
        {
            piece.Init();
        }
        GameController.OnReset += DestroySelf;
    }
    public void DestroySelf()
    {
        GameController.OnReset -= DestroySelf;
        Destroy(this.gameObject);
    }

}
