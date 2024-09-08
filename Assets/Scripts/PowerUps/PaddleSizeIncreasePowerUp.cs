using UnityEngine;

public class PaddleSizeIncreasePowerUp : PowerUpBase
{

    private float sizeIncreaseFactor = 1.5f;


    public override void ApplyPowerUp(PaddlePowerUpController paddlePowUpCont)
    {
        GameObject paddle = paddlePowUpCont.paddle;
        Vector3 currentScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(currentScale.x * sizeIncreaseFactor, currentScale.y, currentScale.z);

    }

    public override void DeactivatePowerUp(PaddlePowerUpController paddlePowUpCont)
    {
        GameObject paddle = paddlePowUpCont.paddle;
        Vector3 currentScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(currentScale.x / sizeIncreaseFactor, currentScale.y, currentScale.z);

        Destroy(gameObject);
    }


}
