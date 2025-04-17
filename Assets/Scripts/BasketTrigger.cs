using UnityEngine;

public class BasketTrigger : MonoBehaviour
{
    public int score = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            score++;
            Debug.Log("Canasta! Puntuación: " + score);
            Destroy(other.gameObject); // Opcional: destruir la pelota
        }
    }
}
