using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Master ship controller.
/// </summary>
public class ShipController : MonoBehaviour
{
    [SerializeField] private ShipMovement movement;
    public ShipMovement Movement { get => movement; }

    [SerializeField] private ShipShooting shooting;
    public ShipShooting ShipShooting { get => shooting; }

    [SerializeField] private ShipInput input;
    public ShipInput Input { get => input; }

    [SerializeField] private ShipAnimator anim;
    public ShipAnimator Anim { get => anim; } 

    [SerializeField] private Transform centrePoint;
    public Vector3 CentrePoint { get => centrePoint.position; }

    /// <summary>
    /// Start all of the ships processes.
    /// </summary>
    public void Init()
    {
        movement.Init(this);
        input.Init(this);
        anim.Init(this);
        shooting.Init(this);
    }

}
