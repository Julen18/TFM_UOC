using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpecialScript : NetworkBehaviour
{
    private AudioSource audioSourceController;
    public static AudioClip[] clips;

    void Start()
    {
        clips = Resources.LoadAll<AudioClip>("Sounds");
        
        
    }

    void Update()
    {
        if (Input.anyKey) {
            
            Debug.Log(Input.anyKey);
        }
        switch (Input.anyKey)
        {
            /*case KeyCode.Alpha6: Debug.Log("HOLA, pressed 6");
                break;
            case 7: Debug.Log("Adios, pressed 7");
                break;*/
           
        }
    }
}
