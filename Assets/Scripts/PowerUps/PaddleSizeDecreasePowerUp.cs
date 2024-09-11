using UnityEngine;

public class PaddleSizeDecreasePowerUp : PowerUpBase
{
    public float sizeDecreaseFactor = 0.5f;

    public override void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        GameObject paddle = paddlePowerUpController.paddle;
        Vector3 currentScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(currentScale.x * sizeDecreaseFactor, currentScale.y, currentScale.z);

        ActivatePowerUpBar(paddlePowerUpController, Color.red);
    }

    public override void DeactivatePowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        GameObject paddle = paddlePowerUpController.paddle;
        Vector3 currentScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(currentScale.x / sizeDecreaseFactor, currentScale.y, currentScale.z);

        DeactivatePowerUpBar(paddlePowerUpController);

        Destroy(gameObject);
    }
}
