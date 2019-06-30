using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StartLocalGame : MonoBehaviour
{
    private NetworkManager networkManager;

    private void Start()
    {
        try
        {
            networkManager = NetworkManager.singleton;

            networkManager.StopMatchMaker();

            networkManager.StartHost();
        }
        catch
        {

        }

    }

}
