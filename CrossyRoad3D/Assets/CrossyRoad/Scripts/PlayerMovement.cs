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

    // Parametro = direccion a la que nos vamos a mover
    private void Move(Vector3 direction)
    {
        transform.position += direction * stepSize; // nueva posicion del jugador
    }

    void Update()
    {
        //Si se presiona W o se presiona flecha hacia arrba
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            Move(Vector3.forward); // Mover hacia adelante
        }
    }
}
