using UnityEngine;


public class PaddlePowerUpController : MonoBehaviour
{
    public PowerUpBase activePowerUp;
    private Coroutine activeCoroutine;

    public GameObject ball;
    public GameObject paddle;

    public Player CurPlayer => ParameterManager.Instance.player;
    public PlayerHealthUI CurHealthUI => ParameterManager.Instance.healthUI;


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


    /*
        New property: If a new power-up hits paddle object while another power-up is active, 
        stop the old one and activate the new one.
    */

    public void CheckPowerUp(PowerUpBase powerUpComponent)
    {
        if (powerUpComponent != null)
        {
            // Mevcut bir power-up aktifse, önce onu devre dýþý býrak
            if (activePowerUp != null)
            {

                // Mevcut Coroutine aktifse, onu devre dýþý býrak
                if (activeCoroutine != null)
                {
                    StopCoroutine(activeCoroutine);
                }

                activePowerUp.DeactivatePowerUp(this);
            }


            // Yeni power-up'ý etkinleþtir ve aktif power-up olarak kaydet
            activePowerUp = powerUpComponent;

            activePowerUp.ApplyPowerUp(this);

            activeCoroutine = StartCoroutine(activePowerUp.DeactivateAfterDuration(this));
        }
    }
}

