using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnimator : MonoBehaviour
{
    public ShipMovement movement;
    [SerializeField] private ParticleSystem leftBoost, rightBoost;
    [SerializeField] private float basicParticleRate;

    public void Init(ShipController controller)
    {
        movement = controller.Movement;
        MainCoroutine.OnMainUpdate += UpdateBoosters;
    }

    private void OnDisable()
    {
        MainCoroutine.OnMainUpdate -= UpdateBoosters;
    }

    public void UpdateBoosters(float time)
    {
        var emission = leftBoost.emission;
        emission.rateOverTime = movement.Acceleration * basicParticleRate;
        emission = rightBoost.emission;
        emission.rateOverTime = movement.Acceleration * basicParticleRate;
    }
}
