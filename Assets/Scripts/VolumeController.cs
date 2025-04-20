using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public AudioMixer mixer;

    public static VolumeController Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // ya hay uno, lo borramos
        }
    }

    public void SetMasterVolume(float volume)
    {
        // El volumen en el mixer va de -80 (silencio) a 0 (máximo)
        mixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }
}
