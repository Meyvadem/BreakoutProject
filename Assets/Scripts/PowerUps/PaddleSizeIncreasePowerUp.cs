using UnityEngine;

public class PaddleSizeIncreasePowerUp : PowerUpBase
{

    private float sizeIncreaseFactor = 1.5f;


    public override void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        GameObject paddle = paddlePowerUpController.paddle;
        Vector3 currentScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(currentScale.x * sizeIncreaseFactor, currentScale.y, currentScale.z);

        ActivatePowerUpBar(paddlePowerUpController, Color.blue);
    }

    public override void DeactivatePowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        GameObject paddle = paddlePowerUpController.paddle;
        Vector3 currentScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(currentScale.x / sizeIncreaseFactor, currentScale.y, currentScale.z);

        DeactivatePowerUpBar(paddlePowerUpController);

        Destroy(gameObject);
    }


}
