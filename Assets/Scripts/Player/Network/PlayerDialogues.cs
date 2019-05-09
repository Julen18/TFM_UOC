using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDialogues : MainPlayerClass
{

    //public Canvas dialogue;
    public Text main_text;
    public Text next_text;//aux

    private string textToShow = "";
    private string textAux = "";//aux

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fill_text() {



    }

    public void OnOffDialogue(bool k)
    {
        this.gameObject.SetActive(k);
    }

}
