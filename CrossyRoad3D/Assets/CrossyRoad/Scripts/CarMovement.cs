using Unity.VisualScripting;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Velocidad de movimiento del carro
    [SerializeField] private int xMax = 15; // Posicion en x a la que el carro se destruye

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
        }
    }
}
