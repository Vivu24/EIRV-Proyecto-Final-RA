using UnityEngine;

public class PlatformComponent : MonoBehaviour
{
    private Collider platformCollider;

    void Start()
    {
        platformCollider = GetComponent<Collider>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Si el jugador va hacia arriba (subiendo)
                if (rb.velocity.y > 0)
                {
                    platformCollider.enabled = false;
                }
                else
                {
                    platformCollider.enabled = true;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Asegurarse de que el collider se vuelva a activar al salir
            platformCollider.enabled = true;
        }
    }
}
