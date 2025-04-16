using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicaBotones : MonoBehaviour
{
    private GameObject objetoDucha;
    private GameObject menuPausa;

    private void Start()
    {
        objetoDucha = GameObject.FindWithTag("Ducha");
        if(objetoDucha != null)
            objetoDucha.SetActive(false);

        menuPausa = GameObject.FindWithTag("MenuPausa");
        if (menuPausa != null)
            menuPausa.SetActive(false);
    }

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
        //SceneManager.LoadScene("ARGame");
    }
    public void Dormir()
    {
        //SceneManager.LoadScene("ARGame");
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
