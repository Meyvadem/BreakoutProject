

public class LifeIncreasePowerUp : PowerUpBase
{
    public override void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        int live = ++paddlePowerUpController.CurPlayer.currentLives;
        paddlePowerUpController.CurHealthUI.UpdateLivesUI(live);

        Destroy(gameObject);

    }


}
