using UnityEngine;

public class BallSizeDecreasePowerUp : PowerUpBase
{

    public float sizeDecreaseFactor = 0.5f;
    public GameObject poisonTimerPrefab;

    public override void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController)
    {

        GameObject ball = paddlePowerUpController.ball;
        if (ball != null)
        {
            Vector3 currentScale = ball.transform.localScale;
            ball.transform.localScale = currentScale * sizeDecreaseFactor;


            // Rigidbody kütlesini güncelleme 
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.mass *= Mathf.Pow(sizeDecreaseFactor, 3);
            }

            Debug.Log("Ball size decreased!");
        }
        else
        {
            Debug.LogWarning("Ball reference is not set.");
        }

        PowerUpTimer = paddlePowerUpController.powerUpTimer;

        PowerUpTimer.timerPrefab = poisonTimerPrefab;

        paddlePowerUpController.TimerUI.ActivatePowerUpBar(this);

    }

    protected override void OnDeactivatePowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        GameObject ball = paddlePowerUpController.ball;
        if (ball != null)
        {
            Vector3 currentScale = ball.transform.localScale;
            ball.transform.localScale = currentScale / sizeDecreaseFactor;


            // Rigidbody'nin kütlesini orijinal haline döndür
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.mass /= Mathf.Pow(sizeDecreaseFactor, 3);
            }

            Debug.Log("Ball size returned to normal!");
        }
        else
        {
            Debug.LogWarning("Ball reference is not set.");
        }



    }
}
