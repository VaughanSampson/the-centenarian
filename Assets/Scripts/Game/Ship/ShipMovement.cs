using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls ship based on ShipInput
/// </summary>
public class ShipMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigidBody;

    /// <summary>
    /// Sets up ShipInput.
    /// </summary>
    /// <param name="controller">Master controller of ship.</param>
    public void Init(ShipController controller)
    {
        controller.Input.SetAccelerate += Accelerate;
        controller.Input.SetTrigger += Trigger;
        controller.Input.SetTurnAngle += AddTorque;
    }

    /// <summary>
    /// Recieves force to add to rigidbody.
    /// </summary>
    /// <param name="force"> Force to push. </param>
    public void Accelerate(float force)
    {
        rigidBody.AddForce(force * 100 * transform.up);
    }

    public void Trigger(bool down)
    {
        if(down)
            transform.position = new Vector3(0,1,0);
        else
            transform.position = new Vector3(0,0,0); 
    }

    public void AddTorque(float torque)
    {
        rigidBody.AddTorque(torque);
    }
}
