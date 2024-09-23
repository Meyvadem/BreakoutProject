using UnityEngine;

public class PaddleSizeIncreasePowerUp : PowerUpBase
{

    private float sizeIncreaseFactor = 1.5f;
    public GameObject shieldTimerPrefab;

    public override void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        GameObject paddle = paddlePowerUpController.paddle;
        Vector3 currentScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(currentScale.x * sizeIncreaseFactor, currentScale.y, currentScale.z);

        //   ActivatePowerUpBar(paddlePowerUpController, Color.blue);

        PowerUpTimer = paddlePowerUpController.powerUpTimer;

        PowerUpTimer.timerPrefab = shieldTimerPrefab;
        paddlePowerUpController.TimerUI.ActivatePowerUpBar(this);

    }


    protected override void OnDeactivatePowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        GameObject paddle = paddlePowerUpController.paddle;
        Vector3 currentScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(currentScale.x / sizeIncreaseFactor, currentScale.y, currentScale.z);

    }


}
