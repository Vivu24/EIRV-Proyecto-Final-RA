using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float moveForce = 5f;
    private Rigidbody rb;
    private bool canJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(Vector3.back);
        }

        if (canJump)
        {
            Jump();
            canJump = false;
        }
    }

    void Move(Vector3 direction)
    {
        rb.AddForce(direction * moveForce, ForceMode.Impulse);
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            canJump = true;
        }
    }
}
