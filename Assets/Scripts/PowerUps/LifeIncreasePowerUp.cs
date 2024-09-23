
using UnityEngine;

public class LifeIncreasePowerUp : PowerUpBase
{
    public GameObject heartTimerPrefab;


    private void Start()
    {
        PowerUpDuration = 5f;
    }

    public override void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        int live = ++paddlePowerUpController.CurPlayer.currentLives;
        paddlePowerUpController.CurHealthUI.UpdateLivesUI(live);


        PowerUpTimer = paddlePowerUpController.powerUpTimer;

        PowerUpTimer.timerPrefab = heartTimerPrefab;

        paddlePowerUpController.TimerUI.ActivatePowerUpBar(this);
    }




}


