using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}