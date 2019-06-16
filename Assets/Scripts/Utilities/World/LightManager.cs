using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{

    private bool isLightsOn;
    private GameObject[] ligths;
    // Start is called before the first frame update
    void Start()
    {
        ligths = new GameObject[this.gameObject.transform.childCount];
        for(int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            ligths[i] = this.gameObject.transform.GetChild(i).GetChild(0).gameObject;
        }
        SetOffLights();
    }


    public void SetOffLights()
    {
        foreach (GameObject go in ligths)
        {
            go.GetComponent<Light>().enabled = false;
        }
        isLightsOn = false;
    }
    public void SetOnLights()
    {
        foreach (GameObject go in ligths)
        {
            go.GetComponent<Light>().enabled = true;
        }
        isLightsOn = true;
    }
    public bool ReturnState()
    {
        return isLightsOn;
    }
}
