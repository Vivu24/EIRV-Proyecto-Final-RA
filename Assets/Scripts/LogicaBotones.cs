using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicaBotones : MonoBehaviour
{
    private GameObject objetoDucha;
    private GameObject efectoDormir;
    private GameObject menuPausa;

    [SerializeField] GameObject[] frutas;
    [SerializeField] GameObject frutasSpawner;
    private GameObject eatPos;
    [SerializeField] AudioClip sonidoComer;

    [SerializeField] AudioClip sonidoDormir;
    private GameObject bicho;

    private AudioSource audioSource;
    private Vector3 posicionInicialBicho;
    private bool estaDurmiendo = false;

    private void Start()
    {
        objetoDucha = GameObject.FindWithTag("Ducha");
        if(objetoDucha != null)
            objetoDucha.SetActive(false);

        menuPausa = GameObject.FindWithTag("MenuPausa");
        if (menuPausa != null)
            menuPausa.SetActive(false);

        efectoDormir = GameObject.FindWithTag("Dormir");
        if (efectoDormir != null)
            efectoDormir.SetActive(false);

        audioSource = GetComponent<AudioSource>();

        bicho = GameObject.FindWithTag("Player");
        if (bicho != null)
            posicionInicialBicho = bicho.transform.position;
    }

    #region Cambio de Escenas
    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void Jugar()
    {
        SceneManager.LoadScene("ARGame");
    }
    public void Saltos()
    {
        SceneManager.LoadScene("ARSaltos");
    }
    #endregion
    public void Ducha()
    {
        if (objetoDucha != null)
        {
            if (objetoDucha.activeSelf)
            {
                objetoDucha.SetActive(false);
            }
            else
            {
                objetoDucha.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("No se encontró ningún objeto con el tag 'Ducha'.");
        }
    }

    public void Comer()
    {
        GameObject frutaElegida = frutas[Random.Range(0, frutas.Length)];

        Vector3 posicionInicial = eatPos.transform.position + new Vector3(0, 2f, 0);
        GameObject fruta = Instantiate(frutaElegida, posicionInicial, Quaternion.identity, frutasSpawner.transform);

        StartCoroutine(ComerComida(fruta));
    }

    private IEnumerator ComerComida(GameObject fruta)
    {
        float velocidad = 2f;

        while (fruta != null && fruta.transform.position.y > eatPos.transform.position.y + 0.1f)
        {
            Vector3 direccion = (eatPos.transform.position - fruta.transform.position).normalized;
            fruta.transform.position += direccion * velocidad * Time.deltaTime;
            yield return null;
        }

        audioSource.PlayOneShot(sonidoComer);
        Destroy(fruta);
    }

    public void Dormir()
    {
        if (!estaDurmiendo)
        {
            efectoDormir.SetActive(true);

            bicho.transform.position += new Vector3(0, 1.25f, 0);

            audioSource.clip = sonidoDormir;
            audioSource.loop = true;
            audioSource.Play();

            estaDurmiendo = true;
        }
        else
        {
            bicho.transform.position -= new Vector3(0, 1.25f, 0);

            audioSource.Stop();
            audioSource.loop = false;

            efectoDormir.SetActive(false);

            estaDurmiendo = false;
        }
    }

    public void Settings()
    {
        if (menuPausa != null)
        {
            if (menuPausa.activeSelf)
            {
                menuPausa.SetActive(false);
            }
            else
            {
                menuPausa.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("No se encontró ningún objeto con el tag 'MenuPausa'.");
        }
    }
}
