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

    public bool IsServer()
    {
        if (isServer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
