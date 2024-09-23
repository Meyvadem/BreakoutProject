using UnityEngine;

public class PaddleSizeDecreasePowerUp : PowerUpBase
{
    public float sizeDecreaseFactor = 0.5f;
    public GameObject skullTimerPrefab;

    public override void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        GameObject paddle = paddlePowerUpController.paddle;
        Vector3 currentScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(currentScale.x * sizeDecreaseFactor, currentScale.y, currentScale.z);

        PowerUpTimer = paddlePowerUpController.powerUpTimer;

        PowerUpTimer.timerPrefab = skullTimerPrefab;

        paddlePowerUpController.TimerUI.ActivatePowerUpBar(this);
    }

    protected override void OnDeactivatePowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        GameObject paddle = paddlePowerUpController.paddle;
        Vector3 currentScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(currentScale.x / sizeDecreaseFactor, currentScale.y, currentScale.z);



    }
}
