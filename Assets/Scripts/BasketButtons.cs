using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasketButtons : MonoBehaviour
{
    public void OnBackButton()
    {
        SceneManager.LoadScene("ARGame");
    }
    public void OnExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
