using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [Header("Paddle Settings")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private Rigidbody2D rb;

    [Header("Limites")]
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 10f;

    private float input; // input de teclado para mover la paleta

    private void Update()
    {
        input = Input.GetAxis("Horizontal"); // se puede mover con las flechas o con A y D
    }

    private void FixedUpdate()
    {
        float velocityX = input * speed;
        rb.linearVelocity = new Vector3(velocityX, 0f, 0f);

        Vector2 pos = rb.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        rb.position = pos;
    }
}
