using System.Collections;
using System;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private float shootTime;
    [SerializeField] private float maxEnergy, energyCost, energy;



    public void Init(ShipController controller)
    {
        controller.Input.SetTrigger += GetTrigger;
        rigidBody = controller.Movement.RigidBody;
        MainCoroutine.OnMainUpdate += ShootLoop;
    }

    private void OnDisable()
    {
        MainCoroutine.OnMainUpdate -= ShootLoop;

    }

    private bool triggerDown;

    public void GetTrigger(bool down)
    {
        triggerDown = down;
    }

    private float shootTimer;

    public void ShootLoop(float deltaTime)
    {
        if (shootTimer > 0)
            shootTimer -= deltaTime;

        if (energy < maxEnergy)
            energy += deltaTime;

        if (shootTimer <= 0 && triggerDown && energy > 0)
        {
            energy -= energyCost;
            shootTimer = shootTime;
            CreateBullet();
        }
    }

    public void CreateBullet()
    { 
        Bullet bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Initiate(rigidBody.velocity);
    }

}
