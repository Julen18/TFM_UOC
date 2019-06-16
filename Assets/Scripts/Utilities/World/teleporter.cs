using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    private bool canTeleport;
    public GameObject to;

    public bool needKey;
    private bool haveKey;
    public string keyName;

    public GameObject portalEffect;
    // Start is called before the first frame update
    void Start()
    {
        canTeleport = true;
        if (needKey)
        {
            canTeleport = false;
        }
        
    }

    // Update is called once per frame

    public void OnTriggerEnter(Collider other)
    {
        if (needKey && other.tag == "Player" && !haveKey)
        {
            CheckKeyToEnable(other.gameObject);
        }

        if (other.tag == "Player" && canTeleport)
        {
            other.gameObject.transform.position = to.gameObject.transform.position;
            to.GetComponent<teleporter>().DelayTeleport();
        }
    }

    public void DelayTeleport()
    {
        StartCoroutine(delayTel());
    }
    IEnumerator delayTel()
    {
        canTeleport = false;
        yield return new WaitForSeconds(2);
        canTeleport = true;
    }

    public void CheckKeyToEnable(GameObject go)
    {
        if(go.transform.tag == "Player")
        {
            if (go.GetComponentInChildren<InventoryPlayer>().GetItemFromInventorySpecial(keyName))
            {
                haveKey = true;
                ActivePortal();
            }

        } 

    }

    public void ActivePortal()
    {
        //this.portalEffect.SetActive(true);
        canTeleport = true;
    }
}
