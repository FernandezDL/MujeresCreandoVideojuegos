using Unity.VisualScripting;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Velocidad de movimiento del carro
    [SerializeField] private int xMax = 15; // Posicion en x a la que el carro se destruye
    private GameObject losePanel; // Panel que se muestra al perder
    
    private void Start()
    {
        // Busca el Canvas primero
        Canvas canvas = FindObjectOfType<Canvas>();

        if (canvas != null)
        {
            // Busca el panel dentro del Canvas
            losePanel = canvas.transform.Find("LosePanel")?.gameObject;

            if (losePanel != null) // Si se encuentra el panel, lo oculta al inicio del juego
            {
                losePanel.SetActive(false);
            }
            else // Si no se encuentra el panel, muestra una advertencia
            {
                Debug.LogWarning("No se encontró el panel LosePanel dentro del Canvas");
            }
        }
        else // Si no se encuentra el Canvas, muestra una advertencia
        {
            Debug.LogWarning("No se encontró ningún Canvas en la escena");
        }
    }

    private void Update() 
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        if(transform.position.x > xMax)
        {
            Destroy(gameObject); // Destruye el carro cuando se pasa de xMax
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador ha sido atropellado por el carro. Game over");
            Time.timeScale = 0f; // Detiene el tiempo del juego, haciendo que todo se detenga
            losePanel.SetActive(true); // Muestra el panel de derrota
        }
    }
}
