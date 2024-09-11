using UnityEngine;
using UnityEngine.UI;


public class PaddlePowerUpController : MonoBehaviour
{
    public PowerUpBase activePowerUp;
    private Coroutine activeCoroutine;
    public Image powerUpBarColor;
    public Image powerUpBarBack;
    public Image powerUpBarFrame;

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
            // Mevcut bir power-up aktifse, �nce onu devre d��� b�rak
            if (activePowerUp != null)
            {

                // Mevcut Coroutine aktifse, onu devre d��� b�rak
                if (activeCoroutine != null)
                {
                    StopCoroutine(activeCoroutine);
                }

                activePowerUp.DeactivatePowerUp(this);
            }


            // Yeni power-up'� etkinle�tir ve aktif power-up olarak kaydet
            activePowerUp = powerUpComponent;

            activePowerUp.ApplyPowerUp(this);

            activeCoroutine = StartCoroutine(activePowerUp.DeactivateAfterDuration(this));
        }
    }
}


/*
 
 //   New property: If a new power-up hits paddle object while another power-up is active, 
 //   destroy the new power-up. A new power-up can only be activated if no other power-up is active.


public void CheckPowerUp(PowerUpBase powerUpComponent)
    {
        if (powerUpComponent != null)
        {
            // E�er zaten aktif bir power-up varsa, yeni power-up'� yok et ve hi�bir �ey yapma
            if (activePowerUp != null)
            {
                return; // Yeni power-up'� aktifle�tirmeden methodu sonland�r
            }

            // E�er aktif bir power-up yoksa, gelen power-up'� aktif hale getir
            activePowerUp = powerUpComponent;

            activePowerUp.ApplyPowerUp(this);

            activeCoroutine = StartCoroutine(activePowerUp.DeactivateAfterDuration(this));

            powerUpComponent.gameObject.SetActive(false);
        }
    }
}

*/