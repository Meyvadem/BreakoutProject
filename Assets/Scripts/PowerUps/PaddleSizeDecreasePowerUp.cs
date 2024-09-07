using UnityEngine;

public class PaddleSizeDecreasePowerUp : MonoBehaviour, IPowerUp
{
    public float sizeDecreaseFactor = 0.5f;

    public void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        GameObject paddle = paddlePowerUpController.paddle;
        Vector3 currentScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(currentScale.x * sizeDecreaseFactor, currentScale.y, currentScale.z);

    }

    public void DeactivatePowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        GameObject paddle = paddlePowerUpController.paddle;
        Vector3 currentScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(currentScale.x / sizeDecreaseFactor, currentScale.y, currentScale.z);

    }
}
