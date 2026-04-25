using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Scores")]
    [SerializeField] private int score = 0;
    [SerializeField] private int pointsPerBlock = 10;

    private int blocksRemaining;

    private void Start()
    {
        blocksRemaining = GameObject.FindGameObjectsWithTag("Brick").Length;
        Debug.Log("Bloques iniciales: " + blocksRemaining);
    }

    public void AddScore()
    {
        score = score + pointsPerBlock; // score += pointsPerBlock;
        Debug.Log("Puntaje actual: " + score); // imprimir puntaje actual
    }

    public void BlockDestroyed()
    {
        blocksRemaining = blocksRemaining - 1; // blocksRemaining -= 1; blocksRemaining--;
        Debug.Log("Bloques restantes: " + blocksRemaining);

        if(blocksRemaining <= 0)
        {
            Debug.Log("¡Has ganado! FELICITACIONES :D");
        }
    }
}
