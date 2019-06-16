using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsQuest : MonoBehaviour
{

    private bool isQuest;
    private string nameOfItem;

    private string noDestroy;

    public bool persist = false;
    public string namepersist;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string name)
    {
        nameOfItem = name;
    }
    public string GetName()
    {
        return nameOfItem;
    }

    public void SetIsQuest(bool val)
    {
        isQuest = val;
    }
    public bool GetisQuest()
    {
        return isQuest;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            if (persist)
            {
                other.gameObject.GetComponentInChildren<InventoryPlayer>().PutItemInInventorySpecial(namepersist);
                this.gameObject.SetActive(false);
                return;
            }

            other.gameObject.GetComponentInChildren<InventoryPlayer>().PutItemOnQuestInv(this.gameObject.name);

            if (noDestroy == "1")
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }
    }
    public void ObjNoDestroy()
    {
        noDestroy = "1";
    }
}
