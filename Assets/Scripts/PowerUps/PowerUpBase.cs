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
        float elapsedTime = 0f;

        while (elapsedTime < powerUpDuration)
        {
            elapsedTime += Time.deltaTime;
            float remainingTime = powerUpDuration - elapsedTime;

            if (paddlePowerUpController.powerUpBarColor != null)
            {
                paddlePowerUpController.powerUpBarColor.fillAmount = remainingTime / powerUpDuration;
            }

            yield return null;  // Bir sonraki kareye kadar bekle
        }

        DeactivatePowerUp(paddlePowerUpController);
    }

    public void ActivatePowerUpBar(PaddlePowerUpController paddlePowerUpController, Color barColor)
    {
        if (paddlePowerUpController.powerUpBarColor != null)
        {
            paddlePowerUpController.powerUpBarColor.color = barColor;

            paddlePowerUpController.powerUpBarColor.gameObject.SetActive(true);
            paddlePowerUpController.powerUpBarBack.gameObject.SetActive(true);
            paddlePowerUpController.powerUpBarFrame.gameObject.SetActive(true);

            paddlePowerUpController.powerUpBarColor.fillAmount = 1f;
        }
    }

    public void DeactivatePowerUpBar(PaddlePowerUpController paddlePowerUpController)
    {
        if (paddlePowerUpController.powerUpBarColor != null)
        {
            paddlePowerUpController.powerUpBarColor.gameObject.SetActive(false);
            paddlePowerUpController.powerUpBarBack.gameObject.SetActive(false);
            paddlePowerUpController.powerUpBarFrame.gameObject.SetActive(false);

        }
    }
}

