using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Settings")]
    [SerializeField] private int score = 0;
    [SerializeField] private int pointsPerStep = 5;

    [Header("Player")]
    [SerializeField] private Transform playerTransform; // detectar la posicion del jugador

    [Header("UI")]
    [SerializeField] private TMP_Text scoreText; // mostrar el puntaje en pantalla

    private float posicionZ; 

    void Start()
    {
        posicionZ = playerTransform.position.z; // obtener la posicion inicial del jugador
    }

    void Update()
    {
        if(playerTransform.position.z > posicionZ)
        {
            posicionZ = playerTransform.position.z; // actualizar la posicion del jugador

            score += pointsPerStep; // score = score + pointsPerStep
            Debug.Log("Score: " + score);
            scoreText.text = "Puntaje: " + score; // actualizar el texto del puntaje en pantalla
        }
    }
}
