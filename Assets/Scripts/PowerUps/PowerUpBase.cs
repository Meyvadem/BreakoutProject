using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class PowerUpBase : MonoBehaviour
{
    private float powerUpDuration = 5f;
    private Coroutine activeCoroutine;
    private PowerUpTimer powerUpTimer;
    private GameObject instantiatedTimer;


    public abstract void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController);


    public void DeactivatePowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        OnDeactivatePowerUp(paddlePowerUpController);
        paddlePowerUpController.TimerUI.DeactivatePowerUpBar(this);

        paddlePowerUpController.activePowerUps.Remove(this);
        activeCoroutine = null;

        Destroy(gameObject);
    }


    protected virtual void OnDeactivatePowerUp(PaddlePowerUpController paddlePowerUpController)
    {

    }


    public IEnumerator DeactivateAfterDuration(PaddlePowerUpController paddlePowerUpController)
    {
        Image transparentImage = instantiatedTimer.transform.Find("TransparentImage").GetComponent<Image>();

        if (transparentImage != null)
        {
            float elapsedTime = 0f;
            float duration = powerUpDuration;

            transparentImage.fillAmount = 0f;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float fillAmount = elapsedTime / duration;

                transparentImage.fillAmount = fillAmount;

                yield return null;
            }

            DeactivatePowerUp(paddlePowerUpController);
        }
    }


    public void ResetTimer(PaddlePowerUpController paddlePowerUpController)
    {
        if (activeCoroutine != null)
        {
            paddlePowerUpController.StopCoroutine(activeCoroutine);
        }


        activeCoroutine = paddlePowerUpController.StartCoroutine(DeactivateAfterDuration(paddlePowerUpController));

    }


    public float PowerUpDuration
    {
        get { return powerUpDuration; }
        set { powerUpDuration = value; }
    }


    public GameObject InstantiatedTimer
    {
        get { return instantiatedTimer; }
        set { instantiatedTimer = value; }
    }


    public PowerUpTimer PowerUpTimer
    {
        get { return powerUpTimer; }
        set { powerUpTimer = value; }
    }

}

