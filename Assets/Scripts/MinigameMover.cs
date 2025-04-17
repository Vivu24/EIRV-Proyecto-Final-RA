using UnityEngine;

public class MinigameMover : MonoBehaviour
{
    public float scrollSpeed = 1f;
    public Transform player;
    public float scrollThreshold = 3f;

    private float lastPlayerY;
    private bool gameStarted = false;

    void Start()
    {
        if (player != null)
            lastPlayerY = player.localPosition.y;
    }

    void Update()
    {
        if (player == null) return;

        float deltaY = player.localPosition.y - lastPlayerY;

        // Detectar si el jugador hizo el primer salto (o subió suficiente)
        if (!gameStarted && deltaY > scrollThreshold)
        {
            gameStarted = true;
        }

        // Si ya empezó el juego, mover el mundo
        if (gameStarted && deltaY > scrollThreshold)
        {
            float moveAmount = deltaY * scrollSpeed;
            transform.position -= new Vector3(0f, moveAmount, 0f);
            lastPlayerY = player.localPosition.y;
        }
    }
}
