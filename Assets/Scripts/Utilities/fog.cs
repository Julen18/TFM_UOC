using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fog : MonoBehaviour
{
    public GameObject l_map;
    public GameObject l_aux_enemy_map;
    public GameObject l_aux_enemy_map2;

    private float nstart = 0.001f;
    private float nend = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveFog()
    {
       
        RenderSettings.fog = true;
    }
    public void DesactiveFog(){
        RenderSettings.fog = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        ActiveFog();
        StartCoroutine(DelayE());
    }
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(DelayEA());
    }

    IEnumerator DelayE()
    {

        for(float i = nstart; i < 0.1f; i += 0.001f )
        {
            yield return new WaitForSeconds(0.1f);
            RenderSettings.fogDensity = RenderSettings.fogDensity + 0.001f;
            if(RenderSettings.fogDensity > 0.1f)
            {
                break;
            }
        }
        l_map.SetActive(false);
        l_aux_enemy_map.SetActive(true);
        l_aux_enemy_map2.SetActive(true);
    }
    IEnumerator DelayEA()
    {
        for (float i = nend; i > 0.001f; i -= 0.015f)
        {
            yield return new WaitForSeconds(0.1f);
            RenderSettings.fogDensity = RenderSettings.fogDensity - 0.015f;
        }
        DesactiveFog();
        l_map.SetActive(true);
        l_aux_enemy_map.SetActive(false);
        l_aux_enemy_map2.SetActive(false);
    }
}
