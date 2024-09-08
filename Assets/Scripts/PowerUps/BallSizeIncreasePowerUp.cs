using UnityEngine;

public class BallSizeIncreasePowerUp : PowerUpBase
{

    public float sizeIncreaseFactor = 1.5f;


    public override void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        GameObject ball = paddlePowerUpController.ball;
        if (ball != null)
        {
            Vector3 currentScale = ball.transform.localScale;
            ball.transform.localScale = currentScale * sizeIncreaseFactor;


            // Collider boyutunu g�ncelleme
            SphereCollider collider = ball.GetComponent<SphereCollider>();
            if (collider != null)
            {
                collider.radius *= sizeIncreaseFactor;
            }


            // Rigidbody k�tlesini g�ncelleme 
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.mass *= Mathf.Pow(sizeIncreaseFactor, 3);
            }

            Debug.Log("Ball size increased!");
        }
        else
        {
            Debug.LogWarning("Ball reference is not set.");
        }


    }

    public override void DeactivatePowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        GameObject ball = paddlePowerUpController.ball;
        if (ball != null)
        {
            Vector3 currentScale = ball.transform.localScale;
            ball.transform.localScale = currentScale / sizeIncreaseFactor;


            // Collider'�n yar��ap�n� orijinal haline d�nd�r
            SphereCollider collider = ball.GetComponent<SphereCollider>();
            if (collider != null)
            {
                collider.radius /= sizeIncreaseFactor;
            }


            // Rigidbody'nin k�tlesini orijinal haline d�nd�r
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.mass /= Mathf.Pow(sizeIncreaseFactor, 3);
            }

            Debug.Log("Ball size decreased!");
        }
        else
        {
            Debug.LogWarning("Ball reference is not set.");
        }

        Destroy(gameObject);
    }
}
