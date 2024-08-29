using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public float maxPosition;


    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePosition = Input.mousePosition;

        // Mouse pozisyonunun Unity sahnesindeki d�nya koordinatlar�n� hesaplama
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);


        // Paddle position
        Vector3 newPos = transform.position;

        newPos.x = mousePosition.x;

        // Paddle hareketini s�n�rland�rm�� olduk
        newPos.x = Mathf.Clamp(newPos.x, -maxPosition, maxPosition);

        // Paddle new position
        transform.position = newPos;


    }


}
