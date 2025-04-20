using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderBinder : MonoBehaviour
{
    public Slider volumeSlider;

    IEnumerator Start()
    {
        // Esperamos a que exista el VolumeController
        while (VolumeController.Instance == null)
            yield return null;

        volumeSlider.onValueChanged.AddListener(VolumeController.Instance.SetMasterVolume);

        // Inicializa el slider con el valor actual
        float currentVol;
        if (VolumeController.Instance.mixer.GetFloat("MasterVolume", out currentVol))
        {
            volumeSlider.value = Mathf.Pow(10f, currentVol / 20f);
        }
    }
}
