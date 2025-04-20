using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SlottyTouchHandler : MonoBehaviour
{
    public AudioClip slottySound;

    [SerializeField] private float jumpHeight = 0.2f;
    [SerializeField] private float jumpSpeed = 5f;

    [SerializeField] private float shakeDuration = 0.3f;
    [SerializeField] private float shakeMagnitude = 0.05f;

    [SerializeField] private float squishScaleY = 0.9f;
    [SerializeField] private float squishSpeed = 5f;

    [SerializeField] private float spinAngle = 30f;
    [SerializeField] private float spinDuration = 0.3f;

    private bool isAnimating = false;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (isAnimating) return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    OnSlottyTouched();
                }
            }
        }
    }

    void OnSlottyTouched()
    {
        Debug.Log("TOQUE A BICHO");

        int randomAnim = Random.Range(0, 4); // 0-3

        switch (randomAnim)
        {
            case 0:
                StartCoroutine(Bounce());
                break;
            case 1:
                StartCoroutine(Shake());
                break;
            case 2:
                StartCoroutine(Squish());
                break;
            case 3:
                StartCoroutine(Spin());
                break;
        }
    }

    void PlaySlottySound()
    {
        if (slottySound == null) return;

        audioSource.pitch = Random.Range(0.7f, 1.3f);
        audioSource.PlayOneShot(slottySound);
    }

    IEnumerator Bounce()
    {
        isAnimating = true;
        Debug.Log("Bounce!");
        PlaySlottySound();

        Vector3 startPos = transform.localPosition;
        Vector3 upPos = startPos + Vector3.up * jumpHeight;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * jumpSpeed;
            transform.localPosition = Vector3.Lerp(startPos, upPos, t);
            yield return null;
        }

        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * jumpSpeed;
            transform.localPosition = Vector3.Lerp(upPos, startPos, t);
            yield return null;
        }

        isAnimating = false;
    }

    IEnumerator Shake()
    {
        isAnimating = true;
        Debug.Log("Shake!");
        PlaySlottySound();

        Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Mathf.Sin(elapsed * 30f) * shakeMagnitude;
            transform.localPosition = originalPos + new Vector3(x, 0f, 0f);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
        isAnimating = false;
    }

    IEnumerator Squish()
    {
        isAnimating = true;
        Debug.Log("Squish!");
        PlaySlottySound();

        Vector3 originalScale = transform.localScale;
        Vector3 squished = new Vector3(originalScale.x * 1.1f, originalScale.y * squishScaleY, originalScale.z);

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * squishSpeed;
            transform.localScale = Vector3.Lerp(originalScale, squished, t);
            yield return null;
        }

        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * squishSpeed;
            transform.localScale = Vector3.Lerp(squished, originalScale, t);
            yield return null;
        }

        isAnimating = false;
    }

    IEnumerator Spin()
    {
        isAnimating = true;
        Debug.Log("Spin!");
        PlaySlottySound();

        Quaternion startRot = transform.rotation;
        Quaternion endRot = startRot * Quaternion.Euler(0f, spinAngle, 0f);

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / spinDuration;
            transform.rotation = Quaternion.Lerp(startRot, endRot, t);
            yield return null;
        }

        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / spinDuration;
            transform.rotation = Quaternion.Lerp(endRot, startRot, t);
            yield return null;
        }

        isAnimating = false;
    }
}
