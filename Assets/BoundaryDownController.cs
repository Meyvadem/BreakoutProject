using UnityEngine;

public class BoundaryDownController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;

        if (collidedObject != null)
        {
            IPowerUp powerUpComponent = collidedObject.GetComponent<IPowerUp>();
            Destroy(collidedObject);
        }
    }



}
