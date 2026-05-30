using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entro");
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Has ganado!");
            Time.timeScale = 0f; // Detiene el tiempo para mostrar

            winPanel.SetActive(true); // Muestra el panel de victoria
        }
    }
}
