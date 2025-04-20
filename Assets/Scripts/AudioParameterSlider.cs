using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class AudioParameterSlider : MonoBehaviour
{
    public Slider slider;
    public AudioMixer mixer;
    [Tooltip("El nombre del parámetro expuesto en el mixer (ej: MusicVolume)")]
    public string exposedParameter = "MusicVolume";

    IEnumerator Start()
    {
        // Espera al mixer (por si viene de otra escena)
        while (mixer == null)
            yield return null;

        if (slider == null)
            slider = GetComponent<Slider>();

        // Cargar valor actual del mixer
        float value;
        if (mixer.GetFloat(exposedParameter, out value))
        {
            slider.value = Mathf.Pow(10f, value / 20f);
        }

        // Conectar el listener
        slider.onValueChanged.AddListener(SetParameter);
    }

    void SetParameter(float sliderValue)
    {
        // Evitar log10(0)
        sliderValue = Mathf.Clamp(sliderValue, 0.0001f, 1f);
        mixer.SetFloat(exposedParameter, Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat(exposedParameter, sliderValue);
    }
}
