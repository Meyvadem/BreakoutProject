using UnityEngine;

public class PaddlePowerUpController : MonoBehaviour
{

    private Player activePlayer;
    public GameObject ball;
    public GameObject paddle;

    void Start()
    {

        activePlayer = ParameterManager.Instance.player;
    }


    void Update()
    {

    }

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


    public Player GetActivePerson()
    {
        return activePlayer;
    }
}
