using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class CanvasItemsUIQuest : MonoBehaviour
{

    public Text text;
    public GameObject inventory;
    private Dictionary<string, string> trads = new Dictionary<string,string>();
    private int total;

    // Start is called before the first frame update
    void Start()
    {
        FillArrayTrad();
        total = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void SetText(string name)
    {
        int count = GimeData(name);
        text.text = GetTradItem(name) + ": " + count + "/"+total;

    }
    public void SetTotal(int val)
    {
        total = val;

    }
    private int GimeData(string name)
    {

        return inventory.GetComponent<InventoryPlayer>().GetCountItemFromInventoryQuest(name);

    }

    private string GimeTheNameOfItemParsed(string st)
    {

       


        return "";
    }

    private void FillArrayTrad()
    {
        trads.Add("SM_Env_Plant_01", "Planta Azul");
        trads.Add("SM_Prop_Cart_Wheel_01", "Rueda del carro");
    }

    private string GetTradItem(string key)
    {
        return trads[key];
    }
}

/*
public class TextsObjs
{
    public string name;
    public string text;
}

            /*if (Input.GetKeyDown(KeyCode.I))
        {
            RectTransform panelRectTransform = panel.GetComponent<RectTransform>();
            panelRectTransform.sizeDelta = new Vector2(panelRectTransform.sizeDelta.x, panelRectTransform.sizeDelta.y + 15);
            panelRectTransform.localPosition = new Vector3(panelOrigPos.localPosition.x, panelOrigPos.localPosition.y-7.5f, panelOrigPos.localPosition.z);
        }*/
