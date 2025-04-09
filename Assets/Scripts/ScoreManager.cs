using UnityEngine;
using TMPro; // Importante para usar TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    public float fallThreshold = 10f;

    private float highestY = 0f;
    private bool isGameOver = false;

    void Start()
    {
        highestY = player.position.y;
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (isGameOver) return;

        // Actualizar score
        if (player.position.y > highestY)
        {
            highestY = player.position.y;
            scoreText.text = "Puntuación: " + Mathf.FloorToInt(highestY).ToString();
        }

        // Detectar caída
        if (player.position.y < highestY - fallThreshold)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Pausar el juego
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
