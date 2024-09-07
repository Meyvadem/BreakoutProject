using UnityEngine;

public class BallSizeDecreasePowerUp : MonoBehaviour, IPowerUp
{

    public float sizeDecreaseFactor = 0.5f;


    public void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController)
    {

        GameObject ball = paddlePowerUpController.ball;
        if (ball != null)
        {
            Vector3 currentScale = ball.transform.localScale;
            ball.transform.localScale = currentScale * sizeDecreaseFactor;


            // Collider boyutunu g�ncelleme
            SphereCollider collider = ball.GetComponent<SphereCollider>();
            if (collider != null)
            {
                collider.radius *= sizeDecreaseFactor;
            }


            // Rigidbody k�tlesini g�ncelleme 
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.mass *= Mathf.Pow(sizeDecreaseFactor, 3);
            }

            Debug.Log("Ball size decreased!");
        }
        else
        {
            Debug.LogWarning("Ball reference is not set.");
        }
    }

    public void DeactivatePowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        GameObject ball = paddlePowerUpController.ball;
        if (ball != null)
        {
            Vector3 currentScale = ball.transform.localScale;
            ball.transform.localScale = currentScale / sizeDecreaseFactor;


            // Collider'�n yar��ap�n� orijinal haline d�nd�r
            SphereCollider collider = ball.GetComponent<SphereCollider>();
            if (collider != null)
            {
                collider.radius /= sizeDecreaseFactor;
            }


            // Rigidbody'nin k�tlesini orijinal haline d�nd�r
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.mass /= Mathf.Pow(sizeDecreaseFactor, 3);
            }

            Debug.Log("Ball size returned to normal!");
        }
        else
        {
            Debug.LogWarning("Ball reference is not set.");
        }
    }
}
