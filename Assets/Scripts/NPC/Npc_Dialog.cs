using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Dialog : MonoBehaviour
{
    public string npc_name;
    private bool lookAtPl;
    private GameObject target;

    public GameObject haloFocus;
    // Start is called before the first frame update
    void Start()
    {
        lookAtPl = false;

        if (haloFocus)
        {
            haloFocus.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (lookAtPl)
        {
            Vector3 relativePos = target.transform.position - this.transform.position;
            Quaternion newRotation = Quaternion.LookRotation(relativePos, Vector3.up);
            this.transform.rotation = new Quaternion(this.transform.rotation.x, newRotation.y, this.transform.rotation.x, this.transform.rotation.w);
        }
        
    }
    public string getNpcName()
    {
        return this.npc_name;
    }

    public void lookAtPlayer(GameObject ply)
    {
        lookAtPl = true;
        target = ply;
    }

    public void NotlookAtPlayer()
    {
        lookAtPl = false;
    }

    public void ActiveFocus()
    {
        if (!haloFocus.active)
        {
            haloFocus.SetActive(true);
        }

    }

    public void RemoveFocus()
    {
        haloFocus.SetActive(false);
    }

}
