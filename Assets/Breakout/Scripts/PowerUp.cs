using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("PowerUp Settings")]
    [SerializeField] private float fallSpeed = 2f;
    [SerializeField] private float growthAmount = 1.5f;

    private void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {
            Debug.Log("Paleta en crecimiento, power up recogido");

            Vector3 newScale = new Vector3(collision.transform.localScale.x * growthAmount, // Calculamos nuevo tamaño en x
                                            collision.transform.localScale.y, // Asignamos el mismo tamaño en y
                                            collision.transform.localScale.z); // Asignamos el mismo tamaño en z
            collision.transform.localScale = newScale; // Asignamos el nuevo tamaño a la paleta

            Destroy(gameObject); // Destruimos el power up
                                 // IMPORTANTE: no poner Destroy(collision) porque destruimos la paleta
        }
    }
}
