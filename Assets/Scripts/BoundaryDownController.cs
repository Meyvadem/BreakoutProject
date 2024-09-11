using UnityEngine;

public class BoundaryDownController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;

        if (collidedObject != null)
        {
            PowerUpBase powerUpComponent = collidedObject.GetComponent<PowerUpBase>();

            if (powerUpComponent != null)
            {
                Destroy(collidedObject);
            }

        }
    }



}
