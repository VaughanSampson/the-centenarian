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
    }
}
