using UnityEngine;

public class LifeIncreasePowerUp : MonoBehaviour, IPowerUp
{
    public void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        int live = ++paddlePowerUpController.CurPlayer.currentLives;
        paddlePowerUpController.CurHealthUI.UpdateLivesUI(live);

    }


    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;

        if (collidedObject.CompareTag("Line"))
        {

            Destroy(gameObject);
        }
    }


}
