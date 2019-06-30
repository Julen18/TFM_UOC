using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class st : MonoBehaviour
{
    public GameObject loading;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            loading.SetActive(true);
            SceneManager.LoadSceneAsync("Stage_I");
        }
    }
}
