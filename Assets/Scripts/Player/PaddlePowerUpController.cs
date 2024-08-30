using UnityEngine;


public class PaddlePowerUpController : MonoBehaviour
{

    public GameObject ball;
    public GameObject paddle;

    public Player CurPlayer => ParameterManager.Instance.player;
    public PlayerHealthUI CurHealthUI => ParameterManager.Instance.healthUI;


    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;

        if (collidedObject != null)
        {

            IPowerUp powerUpComponent = collidedObject.GetComponent<IPowerUp>();

            CheckPowerUp(powerUpComponent);
            Destroy(collidedObject);


        }
    }

    public void CheckPowerUp(IPowerUp PowerUpPrefab)
    {
        if (PowerUpPrefab != null)
        {
            PowerUpPrefab.ApplyPowerUp(this);
        }

    }
}
