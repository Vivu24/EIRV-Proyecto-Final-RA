using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BasketTrigger : MonoBehaviour
{
    private ParticleSystem particleSystem;

    public int score = 0;
    public float timeLeft = 60f; // 1 minuto

    public TMP_Text scoreText;
    public TMP_Text timerText;

    private AudioSource audioSource;
    [SerializeField] AudioClip sonidoEncestar;

    public GameObject inGameUI;
    public GameObject gameOverUI;

    private bool gameActive = true;

    private void Start()
    {
        particleSystem = GameObject.FindWithTag("Celebration").GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();

        UpdateScoreUI();
        UpdateTimerUI();
    }

    private void Update()
    {
        if (gameActive)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0f)
            {
                timeLeft = 0f;
                gameActive = false;
                GameOver();
            }

            UpdateTimerUI();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!gameActive) return;

        if (other.CompareTag("Ball"))
        {
            score++;
            Debug.Log("Canasta! Puntuación: " + score);

            if (particleSystem != null)
                particleSystem.Play();

            audioSource.PlayOneShot(sonidoEncestar);

            UpdateScoreUI();

            Destroy(other.gameObject); // opcional
        }
    }

    void GameOver()
    {
        inGameUI.SetActive(false);
        gameOverUI.SetActive(true);
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Puntuación: " + score;
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeLeft / 60);
            int seconds = Mathf.FloorToInt(timeLeft % 60);
            timerText.text = string.Format("Tiempo: {0:00}:{1:00}", minutes, seconds);
        }
    }
}
