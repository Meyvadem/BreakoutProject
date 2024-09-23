using UnityEngine;

public class BallSizeIncreasePowerUp : PowerUpBase
{

    public float sizeIncreaseFactor = 1.5f;
    public GameObject starTimerPrefab;

    private void Start()
    {
        PowerUpDuration = 5f;
    }

    public override void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController)
    {

        GameObject ball = paddlePowerUpController.ball;
        if (ball != null)
        {
            Vector3 currentScale = ball.transform.localScale;
            ball.transform.localScale = currentScale * sizeIncreaseFactor;


            // Rigidbody kütlesini güncelleme 
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.mass *= Mathf.Pow(sizeIncreaseFactor, 3);
            }

            Debug.Log("Ball size increased!");
        }
        else
        {
            Debug.LogWarning("Ball reference is not set.");
        }

        PowerUpTimer = paddlePowerUpController.powerUpTimer;

        PowerUpTimer.timerPrefab = starTimerPrefab;

        paddlePowerUpController.TimerUI.ActivatePowerUpBar(this);



    }

    protected override void OnDeactivatePowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        GameObject ball = paddlePowerUpController.ball;
        if (ball != null)
        {
            Vector3 currentScale = ball.transform.localScale;
            ball.transform.localScale = currentScale / sizeIncreaseFactor;


            // Rigidbody'nin kütlesini orijinal haline döndür
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.mass /= Mathf.Pow(sizeIncreaseFactor, 3);
            }

            Debug.Log("Ball size decreased!");
        }
        else
        {
            Debug.LogWarning("Ball reference is not set.");
        }



    }
}
