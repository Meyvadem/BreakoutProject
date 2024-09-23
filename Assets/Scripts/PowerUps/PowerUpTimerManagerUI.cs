using UnityEngine;

public class PowerUpTimerManagerUI : MonoBehaviour
{
    public Transform canvasTransform;
    public Transform panelTransform;


    public void ActivatePowerUpBar(PowerUpBase powerUp)
    {
        if (powerUp.InstantiatedTimer == null)
        {
            if (powerUp.PowerUpTimer != null && powerUp.PowerUpTimer.timerPrefab != null)
            {
                powerUp.InstantiatedTimer = Instantiate(powerUp.PowerUpTimer.timerPrefab, canvasTransform);
                powerUp.InstantiatedTimer.transform.SetParent(panelTransform, true);
            }
        }
        /*
        // Timer var veya yeni oluþturulduysa, süresini sýfýrla
        if (powerUp.InstantiatedTimer != null)
        {
            ResetPowerUpBarTimer(powerUp);
        }*/
    }

    public void DeactivatePowerUpBar(PowerUpBase powerUp)
    {

        if (powerUp.InstantiatedTimer != null)
        {
            Destroy(powerUp.InstantiatedTimer);
            powerUp.InstantiatedTimer = null;
        }
    }

    /*
    public void ResetPowerUpBarTimer(PowerUpBase powerUp)
    {
        Image transparentImage = powerUp.InstantiatedTimer.transform.Find("TransparentImage").GetComponent<Image>();

        if (transparentImage != null)
        {
            // Zamanlayýcýyý sýfýrla
            powerUp.StartCoroutine(UpdatePowerUpBar(transparentImage, powerUp.PowerUpDuration));
        }
    }

    private IEnumerator UpdatePowerUpBar(Image transparentImage, float duration)
    {
        float elapsedTime = 0f;
        transparentImage.fillAmount = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transparentImage.fillAmount = elapsedTime / duration;
            yield return null;
        }
    }*/
}
