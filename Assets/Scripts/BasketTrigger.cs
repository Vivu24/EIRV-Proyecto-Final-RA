using UnityEngine;

public class BasketTrigger : MonoBehaviour
{
    private ParticleSystem particleSystem;

    public int score = 0;

    private void Start()
    {
        particleSystem = GameObject.FindWithTag("Celebration").GetComponent<ParticleSystem>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            score++;
            Debug.Log("Canasta! Puntuación: " + score);

            if(particleSystem != null)
                particleSystem.Play();

            Destroy(other.gameObject); // Opcional: destruir la pelota
        }
    }
}
