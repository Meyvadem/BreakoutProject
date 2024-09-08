using System.Collections;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    protected float powerUpDuration = 5f;

    public abstract void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController);


    public virtual void DeactivatePowerUp(PaddlePowerUpController paddlePowerUpController)
    {

    }

    public IEnumerator DeactivateAfterDuration(PaddlePowerUpController paddlePowerUpController)
    {
        yield return new WaitForSeconds(powerUpDuration);
        DeactivatePowerUp(paddlePowerUpController);

    }


}

