using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool requiredKey;
    public string nameOfKey;
    private string IS_OPENED = "IS_OPENED";
    private string IS_CLOSED = "IS_CLOSED";

    public string dopen;
    public string dclose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {


        if(other.tag == "Player")
        {
            if (requiredKey)
            {
                if (CheckPlayerKey(other) && this.gameObject.GetComponentInParent<Animator>().GetCurrentAnimatorClipInfo(0).ToString() != dopen)
                {
                    this.gameObject.GetComponentInParent<Animator>().SetBool("OPEN", true);
                }
            }
            else if (this.gameObject.GetComponentInParent<Animator>().GetCurrentAnimatorClipInfo(0).ToString() != dopen)
            {
                this.gameObject.GetComponentInParent<Animator>().SetBool("OPEN", true);
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (CheckPlayerKey(other) && this.gameObject.GetComponentInParent<Animator>().GetCurrentAnimatorClipInfo(0).ToString() != dclose)
            {
                this.gameObject.GetComponentInParent<Animator>().SetBool("CLOSE", true);
            }
            else if (this.gameObject.GetComponentInParent<Animator>().GetCurrentAnimatorClipInfo(0).ToString() != dclose)
            {
                this.gameObject.GetComponentInParent<Animator>().SetBool("CLOSE", true);
            }
        }
    }

    private bool CheckPlayerKey(Collider player)
    {
        return player.gameObject.GetComponentInChildren<InventoryPlayer>().GetItemFromInventorySpecial(nameOfKey);
    }


}
