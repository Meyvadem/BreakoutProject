using UnityEngine;

public class BallSizeIncreasePowerUp : MonoBehaviour, IPowerUp
{

    public float sizeIncreaseFactor = 1.5f;


    void Start()
    {

    }

    public void ApplyPowerUp(PaddlePowerUpController paddlePowerUpController)
    {
        GameObject ball = paddlePowerUpController.ball;
        if (ball != null)
        {
            Vector3 currentScale = ball.transform.localScale;
            ball.transform.localScale = currentScale * sizeIncreaseFactor;

            // Collider boyutunu güncelleme
            SphereCollider collider = ball.GetComponent<SphereCollider>();
            if (collider != null)
            {
                collider.radius *= sizeIncreaseFactor;
            }

            // Rigidbody kütlesini güncelleme (isteðe baðlý)
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.mass *= Mathf.Pow(sizeIncreaseFactor, 3); // Hacme göre kütle artýþý


            }

            Debug.Log("Ball size increased!");
        }
        else
        {
            Debug.LogWarning("Ball reference is not set.");
        }
    }
}
