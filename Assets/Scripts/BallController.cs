using UnityEngine;

public class BallController : MonoBehaviour
{

    public Transform paddleTransform;
    private Transform initialBallTransform;

    public float speed = 10f; // Topun h�z�
    private Vector3 direction; // Topun hareket y�n�



    void Start()
    {
        initialBallTransform = transform;

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

            ReflectBallDirection(collision); // Topun y�n�n� �arp��ma normaline g�re yans�tma
        }

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
        transform.position = new Vector3(0f, initialBallTransform.position.y, initialBallTransform.position.z + 2f);

        // Topun hareket y�n�n� ayarlama
        SetRandomDirection();

    }


    private void SetRandomDirection()
    {
        float randomX = Random.Range(-0.6f, 0.6f);
        float randomZ = Random.Range(0.6f, 1f);
        direction = new Vector3(randomX, 0, randomZ).normalized;
    }


    private void MoveBall()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }


}
