using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    [Header("PowerUp")]
    [SerializeField] private GameObject powerupPrefab;
    [SerializeField] private float powerupSpawnChance = 0.8f; // probabilidad de que aparezca un power up

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>(); //Buscar el GameManager en la escena
                                                            // Asignarlo a la variable gameManager
    }

    // PRIVATE - Visibilidad
    // VOID - Tipo de la funcion (Significa que no devuelve nada)
    // OnCollisionEnter2D - nombre de la funcion
    // EN EL PARENTESIS - datos que recive
    // Collision2D - tipo 
    // collision - el nombre
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Chequear que el objeto con el que se colisino tenga el tag "Ball"
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Colision de pelota con bloque");
            gameManager.AddScore(); // Llamar a la funcion AddScore del script de GameManager
            gameManager.BlockDestroyed(); // Llamar a la funcion BlockDestroyed del script de GameManager
            Destroy(gameObject); // eliminamos el objeto que tiene el archivo (el bloque)

            float randomValue = Random.value; // Random.value devuelve un valor entre 0.0 y 1.0
            Debug.Log("Valor aleatorio para spawn de power up: " + randomValue);

            if(randomValue < powerupSpawnChance)
            {
                // Crear (instanciar) el power up
                // Primer paramtetro: Prefab a spawnear
                // Segndo parametro: Posicion - posicion del bloque
                // Tercer parametro: Rotacion - sin rotacion (Quaternion.identity)
                Instantiate(powerupPrefab, transform.position, Quaternion.identity); 
                Debug.Log("Power up generado");
            }
        }
    }
}
