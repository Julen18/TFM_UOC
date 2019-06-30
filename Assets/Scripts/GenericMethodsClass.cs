using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 class for Generic Methods and utilities
*/
public abstract class GenericMethodsClass : MonoBehaviour
{
    public int GetRandom(int min, int max)
    {
        return Random.Range(min, max);
    }

    
}
