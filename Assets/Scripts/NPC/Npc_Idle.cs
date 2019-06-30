using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Idle : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        anim.enabled = false;
        Invoke("StartAnim", Random.Range(0,10));
    }

    private void StartAnim()
    {
        anim.enabled = true;
    }
}
