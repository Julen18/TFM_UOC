using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialScript : MonoBehaviour
{

    public GameObject[] effects;  

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void DoSomething()
    {
        DelayEffects();
        

    }
    public void DelayEffects()
    {
        StartCoroutine(DelayE());
    }
    IEnumerator DelayE()
    {
        foreach (GameObject g in effects)//named instantiate but are go to active
        {
            yield return new WaitForSeconds(2);
            g.SetActive(true);
        }
        Destroy(this.gameObject, 2f);
    }
}
