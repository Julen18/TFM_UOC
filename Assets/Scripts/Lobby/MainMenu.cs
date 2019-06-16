using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("History");
    }
    public void OptionsGame()
    {
        //SceneManager.LoadScene("Options");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
