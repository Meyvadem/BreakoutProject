using System.Collections.Generic;
using UnityEngine;


public class PaddlePowerUpController : MonoBehaviour
{
    public List<PowerUpBase> activePowerUps = new List<PowerUpBase>();

    public GameObject ball;
    public GameObject paddle;

    public PowerUpTimer powerUpTimer;
    public Player CurPlayer => ParameterManager.Instance.player;
    public PlayerHealthUI CurHealthUI => ParameterManager.Instance.healthUI;
    public PowerUpTimerManagerUI TimerUI => ParameterManager.Instance.TimerUI;




    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;

        if (collidedObject != null)
        {
            PowerUpBase powerUpComponent = collidedObject.GetComponent<PowerUpBase>();

            CheckPowerUp(powerUpComponent);
            collidedObject.SetActive(false);
        }
    }


    public void CheckPowerUp(PowerUpBase powerUpComponent)
    {
        if (powerUpComponent != null)
        {
            PowerUpBase sameTypePowerUp = activePowerUps.Find(p => p.GetType() == powerUpComponent.GetType());

            if (sameTypePowerUp != null)
            {

                Destroy(powerUpComponent.gameObject);

                sameTypePowerUp.ResetTimer(this);

            }
            else
            {

                activePowerUps.Add(powerUpComponent);

                powerUpComponent.ApplyPowerUp(this);

                powerUpComponent.ResetTimer(this);
            }

        }
    }

}




