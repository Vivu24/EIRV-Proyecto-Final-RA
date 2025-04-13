using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuCanvas;

    public GameObject jumpMinigame;
    public GameObject houseEnviroment;
    public GameObject light;

    public static GameManager Instance { get; private set; }

    public enum GameState { Playing, GameOver, Paused }
    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persiste entre escenas si lo necesitás
        }
        else
        {
            Destroy(gameObject); // Evita duplicados
            return;
        }

        CurrentState = GameState.Playing;
    }

    public void SetGameOver()
    {
        if (CurrentState != GameState.GameOver)
        {
            CurrentState = GameState.GameOver;
            Time.timeScale = 0f;
            Debug.Log("Game Over");

            // Lógica adicional: mostrar panel, guardar score, etc.
        }
    }

    public void PauseGame()
    {
        if (CurrentState == GameState.Playing)
        {
            CurrentState = GameState.Paused;
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        if (CurrentState == GameState.Paused)
        {
            CurrentState = GameState.Playing;
            Time.timeScale = 1f;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        CurrentState = GameState.Playing;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void PlayJumpMinigame()
    {
        Time.timeScale = 1f; // Asegura que el juego no quede pausado
        jumpMinigame.SetActive(true);
        houseEnviroment.SetActive(false);
        menuCanvas.SetActive(false);
    }
    public void GoToBed()
    {
        Time.timeScale = 1f; // Asegura que el juego no quede pausado
        light.SetActive(false);
    }
}
