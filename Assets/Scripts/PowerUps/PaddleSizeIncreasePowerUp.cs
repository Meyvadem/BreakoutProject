using UnityEngine;

public class PaddleSizeIncreasePowerUp : MonoBehaviour, IPowerUp
{

    public float sizeDecreaseFactor = 2.5f;

    public void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        GameObject paddle = paddlePowerUpController.paddle;
        Vector3 currentScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(currentScale.x * sizeDecreaseFactor, currentScale.y, currentScale.z);

    }
}
