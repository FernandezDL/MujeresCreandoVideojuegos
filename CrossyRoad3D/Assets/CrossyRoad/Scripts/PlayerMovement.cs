using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float stepSize = 1f;
    [SerializeField] private float rayDistance = 1f; // distancia del raycast

    // Mueve al jugador en la dirección indicada
    private void Move(Vector3 direction)
    {
        if (CanMove(direction))
        {
            transform.position += direction * stepSize;
        }
    }

    // Verifica si el jugador puede moverse
    private bool CanMove(Vector3 direction)
    {
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;

        // Lanza un raycast
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // Si colisiona con un objeto que sea de tipo "Obstaculo", bloquea
            if (hit.collider.CompareTag("Obstaculo"))
                return false;
        }

        return true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            Move(Vector3.forward);

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            Move(Vector3.back);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            Move(Vector3.left);

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            Move(Vector3.right);
    }
}