using UnityEngine;

public class PlayerMobileController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float moveSpeed = 5f;

    private Rigidbody rb;

    private bool moveLeft = false;
    private bool moveRight = false;
    private bool canJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 velocity = rb.velocity;

        // Movimiento lateral sostenido
        if (moveLeft)
        {
            velocity.x = -moveSpeed;
        }
        else if (moveRight)
        {
            velocity.x = moveSpeed;
        }
        else
        {
            velocity.x = 0; // Deja de moverse si no se toca nada
        }

        rb.velocity = new Vector3(velocity.x, velocity.y, velocity.z);

        // Salto
        if (canJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            canJump = false;
        }
    }

    public void OnLeftButtonDown()
    {
        moveLeft = true;
    }

    public void OnLeftButtonUp()
    {
        moveLeft = false;
    }

    public void OnRightButtonDown()
    {
        moveRight = true;
    }

    public void OnRightButtonUp()
    {
        moveRight = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            canJump = true;
        }
    }
}
