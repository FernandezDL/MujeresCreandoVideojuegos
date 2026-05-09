using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // [SerializeField] private float speed = 5f; // Velocidad de movimiento del jugador

    // void Update()
    // {
    //     float horizontalInput = Input.GetAxis("Horizontal");
    //     float verticalInput = Input.GetAxis("Vertical");

    //     Vector3 direccion = new Vector3(horizontalInput, 0, verticalInput);
    //     transform.position += direccion * speed * Time.deltaTime; 
    //     // transform.position = transform.position + (direccion * speed * Time.deltaTime)
    // }

    [SerializeField] private float stepSize = 1f;
    [SerializeField] private float rayDistance = 1f; // Distancia del rayo para detectar colisiones

    // Parametro = direccion a la que nos vamos a mover
    private void Move(Vector3 direction)
    {
        if (canMove(direction)) // Si podemos movernos en esa direccion
        {
            transform.position += direction * stepSize; // Mover al jugador
        } // Si no podemos movernos en esa direccion, no hacemos nada
    }

    private bool canMove(Vector3 direction)
    {
        Ray ray = new Ray(transform.position, direction); // Crear un rayo desde la posicion del jugador en la direccion que queremos movernos

        if(Physics.Raycast(ray, rayDistance))
        {
            return false; // Si el rayo colisiona con algo, no podemos movernos en esa direccion
        }

        return true; // Si el rayo no colisiona con nada, podemos movernos en esa direccion
    }

    void Update()
    {
        //Si se presiona W o se presiona flecha hacia arrba
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            Move(Vector3.forward); // Mover hacia adelante
        }
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            Move(Vector3.back); // Mover hacia atras
        }
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            Move(Vector3.left); // Mover hacia izquierda
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(Vector3.right); // Mover hacia derecha
        }
    }
}
