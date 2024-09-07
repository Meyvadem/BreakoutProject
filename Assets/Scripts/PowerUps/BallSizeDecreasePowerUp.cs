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


            // Collider boyutunu güncelleme
            SphereCollider collider = ball.GetComponent<SphereCollider>();
            if (collider != null)
            {
                collider.radius *= sizeDecreaseFactor;
            }


            // Rigidbody kütlesini güncelleme 
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


            // Collider'ýn yarýçapýný orijinal haline döndür
            SphereCollider collider = ball.GetComponent<SphereCollider>();
            if (collider != null)
            {
                collider.radius /= sizeDecreaseFactor;
            }


            // Rigidbody'nin kütlesini orijinal haline döndür
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
