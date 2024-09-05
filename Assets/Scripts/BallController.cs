using UnityEngine;

public class BallController : MonoBehaviour
{

    public Transform paddleTransform;

    public float speed = 10f; // Topun hýzý
    private Vector3 direction; // Topun hareket yönü



    void Start()
    {

        SetRandomDirection();

    }


    void Update()
    {

        MoveBall();

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.CompareTag("Line"))
        {
            HandleLineCollision();    // Line ile çarpýþma durumu
        }
        else
        {
            HandleBoxCollision(collidedObject);    // Kutularla çarpýþma durumu
        }


        ReflectBallDirection(collision); // Topun yönünü çarpýþma normaline göre yansýtma

    }


    private void HandleLineCollision()
    {
        ParameterManager.Instance.player.LoseLive();
        ResetBallPosition();
    }

    private void HandleBoxCollision(GameObject collidedObject)
    {
        BoxController boxController = collidedObject.GetComponent<BoxController>();
        if (boxController != null)
        {
            boxController.TakeDamage();
        }
    }


    private void ReflectBallDirection(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;   // Çarpýþma yüzeyinin normalini al
        direction = Vector3.Reflect(direction, normal);  // Yeni yön = yansýma (refleksiyon)

        // Y yönünü sýfýrlama
        direction.y = 0;
        direction = direction.normalized;
    }


    public void ResetBallPosition()
    {

        // Paddle pozisyonunu sýfýrlama
        paddleTransform.position = new Vector3(0f, paddleTransform.position.y, paddleTransform.position.z);

        // Topu paddle'ýn üstüne yerleþtirme
        transform.position = paddleTransform.position + new Vector3(0, 0, 1);

        // Topun hareket yönünü ayarlama
        SetRandomDirection();

        // Topu hareket ettirme
        MoveBall();

    }


    private void SetRandomDirection()
    {
        float randomX = Random.Range(0, -0.7f);
        float randomZ = Random.Range(0, -0.7f);
        direction = new Vector3(randomX, 0, randomZ).normalized;
    }


    private void MoveBall()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }


}
