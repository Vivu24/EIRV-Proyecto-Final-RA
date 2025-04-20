using UnityEngine;
using UnityEngine.UI;

public class BallLauncher : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform cameraTransform;

    public float minForce = 5f;
    public float maxForce = 20f;
    public float chargeSpeed = 10f;

    public Slider chargeSlider;

    private float currentForce = 0f;
    private bool isCharging = false;

    public AudioClip throwingSound;
    public AudioSource audioSource;
    void Update()
    {
        if (isCharging)
        {
            currentForce += chargeSpeed * Time.deltaTime;
            currentForce = Mathf.Clamp(currentForce, minForce, maxForce);

            // Actualizar barra
            if (chargeSlider)
                chargeSlider.value = (currentForce - minForce) / (maxForce - minForce);
        }
    }

    public void StartCharging()
    {
        currentForce = minForce;
        isCharging = true;

        if (chargeSlider)
        {
            chargeSlider.gameObject.SetActive(true);
            chargeSlider.value = 0;
        }
    }

    public void ReleaseBall()
    {
        if (isCharging)
        {
            LaunchBall(currentForce);
            isCharging = false;

            if (chargeSlider)
                chargeSlider.gameObject.SetActive(false);
        }
    }
    void LaunchBall(float force)
    {
        audioSource.pitch = Random.Range(0.7f, 1.5f);
        audioSource.PlayOneShot(throwingSound);

        Vector3 spawnPos = cameraTransform.position + cameraTransform.forward * 0.5f;
        GameObject ball = Instantiate(ballPrefab, spawnPos, Quaternion.identity);

        Rigidbody rb = ball.GetComponent<Rigidbody>();
        Vector3 launchDir = cameraTransform.forward * force;
        rb.AddForce(launchDir, ForceMode.Impulse);

        // Aplicar torque para rotación
        Vector3 randomTorque = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ) * force * 0.1f; // Ajusta el multiplicador para controlar la intensidad de la rotación
        rb.AddTorque(randomTorque, ForceMode.Impulse);
    }
}
