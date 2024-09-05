using UnityEngine;

public class BallController : MonoBehaviour
{

    public Transform paddleTransform;

    public float speed = 10f; // Topun h�z�
    private Vector3 direction; // Topun hareket y�n�



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
            HandleLineCollision();    // Line ile �arp��ma durumu
        }
        else
        {
            HandleBoxCollision(collidedObject);    // Kutularla �arp��ma durumu
        }


        ReflectBallDirection(collision); // Topun y�n�n� �arp��ma normaline g�re yans�tma

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
        Vector3 normal = collision.contacts[0].normal;   // �arp��ma y�zeyinin normalini al
        direction = Vector3.Reflect(direction, normal);  // Yeni y�n = yans�ma (refleksiyon)

        // Y y�n�n� s�f�rlama
        direction.y = 0;
        direction = direction.normalized;
    }


    public void ResetBallPosition()
    {

        // Paddle pozisyonunu s�f�rlama
        paddleTransform.position = new Vector3(0f, paddleTransform.position.y, paddleTransform.position.z);

        // Topu paddle'�n �st�ne yerle�tirme
        transform.position = paddleTransform.position + new Vector3(0, 0, 1);

        // Topun hareket y�n�n� ayarlama
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
