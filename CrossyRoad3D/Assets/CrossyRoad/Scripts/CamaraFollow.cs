using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // Objecto que vamos a seguir con la camara
    [SerializeField] private Vector3 offset = new Vector3(0, 8, -10); // Distancia de la camara

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogError("Target is null");
            return;
        }

        transform.position = target.position + offset; // nueva Posicion de la camara
    }
}
