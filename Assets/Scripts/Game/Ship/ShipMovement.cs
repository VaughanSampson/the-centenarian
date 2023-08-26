using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls ship based on ShipInput
/// </summary>
public class ShipMovement : MonoBehaviour
{

    [SerializeField] private float speed, rotateSpeed;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float acceleration, angularAcceleration;
    public float Acceleration { get => acceleration; }
    public float AngularAcceleration { get => angularAcceleration; }


    /// <summary>
    /// Sets up ShipInput.
    /// </summary>
    /// <param name="controller">Master controller of ship.</param>
    public void Init(ShipController controller)
    {
        controller.Input.SetAccelerate += SetAccelerate;
        controller.Input.SetTrigger += Trigger;
        controller.Input.SetTurnAngle += AddTorque;

        MainCoroutine.OnMainUpdate += Accelerate;
    }

    private void OnDisable()
    {
        MainCoroutine.OnMainUpdate -= Accelerate;
    }

    public void SetAccelerate(float acceleration)
    {
        this.acceleration = acceleration * speed;
    }

    public void Accelerate(float deltaTime)
    {

        rigidBody.AddForce(acceleration * deltaTime * transform.up);
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
        rigidBody.AddTorque(torque * rotateSpeed * Acceleration/ speed);
    }
}
