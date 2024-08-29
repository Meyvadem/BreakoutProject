using UnityEngine;

public class BallController : MonoBehaviour
{

    public Transform paddleTransform;

    public float speed = 10f; // Topun h�z�
    private Vector3 direction; // Topun hareket y�n�



    void Start()
    {
        // Rastgele bir ba�lang�� y�n� belirleyin
        float randomX = Random.Range(0, 1f);
        float randomZ = Random.Range(0, 1f);
        direction = new Vector3(randomX, 0, randomZ).normalized;

    }


    void Update()
    {

        transform.Translate(direction * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Line"))
        {
            ParameterManager.Instance.player.LoseLive();
            ResetBallPosition();
        }

        BoxController boxController = collision.gameObject.GetComponent<BoxController>();
        if (boxController != null)
        {

            boxController.TakeDamage();
        }

        // �arp��ma y�zeyinin normalini al
        Vector3 normal = collision.contacts[0].normal;

        // Yeni y�n = yans�ma (refleksiyon)
        direction = Vector3.Reflect(direction, normal);
    }



    public void ResetBallPosition()
    {
        float randomX1 = Random.Range(0, -0.7f);
        float randomZ1 = Random.Range(0, -0.7f);

        // Paddle pozisyonunu s�f�rlama
        paddleTransform.position = new Vector3(0f, paddleTransform.position.y, paddleTransform.position.z);

        // Topu paddle'�n �st�ne yerle�tirme
        transform.position = paddleTransform.position + new Vector3(0, 0, 1);

        // Topun hareket y�n�n� ayarlama
        direction = new Vector3(randomX1, 0, randomZ1).normalized;

        // Topu hareket ettirme
        transform.Translate(direction * speed * Time.deltaTime);

    }

}
