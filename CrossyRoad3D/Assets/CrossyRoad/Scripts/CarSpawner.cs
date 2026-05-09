using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject carPrefab; // Prefab del carro a instanciar
    [SerializeField] private float spawnTime = 2f; // Tiempo entre cada aparición de carro

    private void Start()
    {
        InvokeRepeating("SpawnCar", 0f, spawnTime); // Llama SpawnCar multiples veces
                                                    // Primero: Nombre del metodo a llamar
                                                    // Segundo: cuando empieza a llamar
                                                    // Tercero: cada cuanto tiempo lo va a llamar
    }

    private void SpawnCar()
    {
        Instantiate(carPrefab, transform.position, transform.rotation);
    }
}
