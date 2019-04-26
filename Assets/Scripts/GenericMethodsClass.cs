using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

/*
 class for Generic Methods and utilities
*/
public abstract class GenericMethodsClass : NetworkBehaviour
{
    public int GetRandom(int min, int max)
    {
        return Random.Range(min, max);
    }

    public void IsNotServer()
    {
        if (!isServer)
        {
            return;
        }
    }
    public void IsServer()
    {
        if (isServer)
        {
            return;
        }
    }
    public void IsNotClient()
    {
        if (!isClient)
        {
            return;
        }
    }
    public void IsClient()
    {
        if (isClient)
        {
            return;
        }
    }
    
}
