using UnityEngine;

public class BallSizeDecreasePowerUp : MonoBehaviour, IPowerUp
{

    public float sizeDecreaseFactor = 0.5f; // Boyut k���ltme katsay�s�

    void Start()
    {

    }

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

            // Rigidbody k�tlesini g�ncelleme (iste�e ba�l�)
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.mass *= Mathf.Pow(sizeDecreaseFactor, 3); // Hacme g�re k�tle azalmas�
            }

            Debug.Log("Ball size decreased!");
        }
        else
        {
            Debug.LogWarning("Ball reference is not set.");
        }
    }
}
