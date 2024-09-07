using UnityEngine;

public class PaddleController : MonoBehaviour
{

    private Camera mainCamera;
    private float maxPosition;
    private float minPosition;
    private float halfPaddleWidth;

    void Start()
    {
        mainCamera = Camera.main;

        maxPosition = 6.8f;
        minPosition = -6.8f;
    }


    void Update()
    {

        UpdatePaddlePosition();

        ClampPaddlePosition();
    }


    private void UpdatePaddlePosition()
    {
        Vector3 mousePosition = Input.mousePosition;

        // Mouse pozisyonunun Unity sahnesindeki dünya koordinatlarýný hesaplama
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Paddle position
        Vector3 newPos = transform.position;
        newPos.x = mousePosition.x;
        transform.position = newPos;
    }


    public void ClampPaddlePosition()
    {
        Vector3 paddlePosition = transform.position;

        halfPaddleWidth = transform.localScale.x / 2;

        // Sað sýnýr kontrolü
        if (paddlePosition.x + halfPaddleWidth > maxPosition)
        {
            paddlePosition.x = maxPosition - halfPaddleWidth;
        }

        // Sol sýnýr kontrolü
        if (paddlePosition.x - halfPaddleWidth < minPosition)
        {
            paddlePosition.x = minPosition + halfPaddleWidth;
        }

        transform.position = paddlePosition;
    }





}
