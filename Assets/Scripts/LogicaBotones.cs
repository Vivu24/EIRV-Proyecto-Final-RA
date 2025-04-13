using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicaBotones : MonoBehaviour
{
    public void Ajustes()
    {
        SceneManager.LoadScene("Ajustes");
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Jugar");
    }
}
