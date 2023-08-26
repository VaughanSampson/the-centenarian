using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Master ship controller.
/// </summary>
public class ShipController : MonoBehaviour
{
    [SerializeField] private ShipMovement movement;
    [SerializeField] private ShipInput input;
    public ShipInput Input { get => input; }
    [SerializeField] private Transform centrePoint;
    public Vector3 CentrePoint { get => centrePoint.position; }

    private void Start()
    {
        Init();
    }

    /// <summary>
    /// Start all of the ships processes.
    /// </summary>
    public void Init()
    {
        movement.Init(this);
        input.Init(this);
    }

}
