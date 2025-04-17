using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    public float launchForce = 10f;
    public float upwardForce = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        // Dirección hacia adelante + fuerza hacia arriba
        Vector3 launchDirection = transform.forward * launchForce + transform.up * upwardForce;

        rb.AddForce(launchDirection, ForceMode.Impulse);
    }
}
