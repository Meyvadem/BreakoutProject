using UnityEngine;

public class PaddlePowerUpController : MonoBehaviour
{

    public GameObject ball;
    public GameObject paddle;

    public Player CurPlayer => ParameterManager.Instance.player;
    public PlayerHealthUI CurHealthUI => ParameterManager.Instance.healthUI;


    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject != null)
        {

            IPowerUp powerUpComponent = collidedObject.GetComponent<IPowerUp>();

            CheckPowerUp(powerUpComponent);
        }

    }

    public void CheckPowerUp(IPowerUp PowerUpPrefab)
    {
        if (PowerUpPrefab != null)
        {
            PowerUpPrefab.ApplyPowerUp(this);
        }
        else
        {
            Debug.LogWarning("Çarpýþan obje bir IPowerUp bileþeni içermiyor.");
        }

    }
}
