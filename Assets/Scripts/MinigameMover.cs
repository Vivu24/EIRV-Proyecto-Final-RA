using UnityEngine;

public class MinigameMover : MonoBehaviour
{
    public float scrollSpeed = 1f;              // Velocidad de movimiento del mundo hacia abajo
    public Transform player;                    // Referencia al jugador
    public float scrollThreshold = 3f;          // Altura que el jugador debe alcanzar para que comience el scroll

    private float initialPlayerY;               // Altura inicial del jugador
    private bool gameStarted = false;           // Controla si el juego ya empezó

    void Start()
    {
        if (player != null)
            initialPlayerY = player.localPosition.y;
    }

    void Update()
    {
        if (player == null) return;

        // Verificar si el jugador ha subido lo suficiente para comenzar el movimiento del mundo
        float totalDeltaY = player.localPosition.y - initialPlayerY;

        if (!gameStarted && totalDeltaY > scrollThreshold)
        {
            gameStarted = true;
        }

        // Mover el mundo hacia abajo de forma constante una vez empezado
        if (gameStarted)
        {
            transform.position -= new Vector3(0f, scrollSpeed * Time.deltaTime, 0f);
        }
    }
}
