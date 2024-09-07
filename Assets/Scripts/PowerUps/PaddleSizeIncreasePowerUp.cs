using UnityEngine;

public class PaddleSizeIncreasePowerUp : MonoBehaviour, IPowerUp
{

    private float sizeIncreaseFactor = 1.5f;


    public void ApplyPowerUp(PaddlePowerUpController paddlePowUpCont)
    {
        GameObject paddle = paddlePowUpCont.paddle;
        Vector3 currentScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(currentScale.x * sizeIncreaseFactor, currentScale.y, currentScale.z);
    }

    public void DeactivatePowerUp(PaddlePowerUpController paddlePowUpCont)
    {
        GameObject paddle = paddlePowUpCont.paddle;
        Vector3 currentScale = paddle.transform.localScale;
        paddle.transform.localScale = new Vector3(currentScale.x / sizeIncreaseFactor, currentScale.y, currentScale.z);
    }


}
