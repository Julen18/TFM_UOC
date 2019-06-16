using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryPlayer : MonoBehaviour
{
    private ArrayList UniqueItemsList;//array dinamyc for store keys, 
    private List<string> questsItemsInventory;//array dinamyc for store keys, 
// private Dictionary<string, int> questsItemsInventory = new Dictionary<string,int>();//Type, quantity
    // Start is called before the first frame update
    void Start()
    {
        UniqueItemsList = new ArrayList();
        questsItemsInventory = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PutItemInInventorySpecial(string item)
    {
        UniqueItemsList.Add(item);
    }
    public bool GetItemFromInventorySpecial(string item)
    {
        return UniqueItemsList.Contains(item);
    }


    public int GetCountItemFromInventoryQuest(string item)
    { 
        return questsItemsInventory.Where(x => x == item).Count();
    }

    public void PutItemOnQuestInv(string name)
    {
        if (name.Contains("Clone"))
        {
            name = name.Remove(name.Length - 7);
        }
        questsItemsInventory.Add(name);

        gameObject.transform.parent.GetComponentInChildren<CanvasItemsUIQuest>().SetText(name);

    }


    public void DeleteItemsQuestType(string name)
    {
        questsItemsInventory.RemoveAll(item => item == name);
    }
}
