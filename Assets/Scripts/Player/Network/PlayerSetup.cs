using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    public Behaviour[] componentsToDisable;
    [SerializeField]
    public GameObject cam;

    Camera sceneCamera;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            //cam.SetActive(false);
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
            {
                Camera.main.gameObject.SetActive(false);
            }
            cam.transform.SetParent(null);
            cam.SetActive(true);
        }
    }

    private void OnDisable()
    {
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
