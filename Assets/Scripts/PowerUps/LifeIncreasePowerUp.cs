using UnityEngine;

public class LifeIncreasePowerUp : MonoBehaviour, IPowerUp
{
    public void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        int live = ++paddlePowerUpController.CurPlayer.currentLives;
        paddlePowerUpController.CurHealthUI.UpdateLivesUI(live);

    }
}
