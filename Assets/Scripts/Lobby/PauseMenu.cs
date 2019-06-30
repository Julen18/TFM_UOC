using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsOn;
    public static bool IsLoading;

    public void LeaveRoom()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("MainStartScene");

    }
}
