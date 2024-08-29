using UnityEngine;

public class LifeIncreasePowerUp : MonoBehaviour, IPowerUp
{


    private void Start()
    {


    }


    public void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController)
    {

        int live = ++paddlePowerUpController.GetActivePerson().currentLives;

        ParameterManager.Instance.healthUI.UpdateLivesUI(live);

    }


}
