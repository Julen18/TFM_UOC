using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class MainMenu : MonoBehaviour
{

    public GameObject cargar;

    private void Start()
    {
        PauseMenu.IsLoading = false;

        string path = Application.persistentDataPath + "/player.fun";
        if (!File.Exists(path))
        {
            cargar.SetActive(false);
        }
    }

    public void StartGame()
    {
        if (!PauseMenu.IsLoading)
        {
            string path = Application.persistentDataPath + "/player.fun";
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            SceneManager.LoadScene("History");
        }
    }

    public void OnlineMode()
    {
        if (!PauseMenu.IsLoading)
        {
            PauseMenu.IsLoading = true;
            SceneManager.LoadSceneAsync("Stage_I");
        }

    }

    public void OptionsGame()
    {
        //SceneManager.LoadScene("Options");
    }
    public void ExitGame()
    {
        if (!PauseMenu.IsLoading) Application.Quit();
    }
}
