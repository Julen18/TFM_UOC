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
    private List<string> dialogAux = new List<string>();
    public GameObject dialoguesManager;

    private int cnt = 0;

    private string goNpc_name;

    private bool npc_selected;

    public GameObject chld;

    // Start is called before the first frame update
    void Start()
    {
        dialoguesManager = GameObject.Find("Dialogue_Manager");
        chld.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && npc_selected)
        {
            Next_text();
        }
        ClickMouse();

    }

    void Fill_text() {
        cnt = 0;
        next_text.text = "Pulsa E para continuar..";
        dialogAux = dialoguesManager.GetComponent<Dialogues>().GetDictionary(goNpc_name);
        Next_text();
    }

    void Next_text() {

        if(cnt == dialogAux.Count)
        {
            OnOffDialogue(false);
            
        }
        if(cnt < dialogAux.Count)
        {
            main_text.text = dialogAux[cnt].ToString();
            cnt++;
        }
       
    }

    public void OnOffDialogue(bool k)
    {
        chld.gameObject.SetActive(k);
    }
    public bool DialogueState()
    {
        return this.gameObject.activeInHierarchy;
    }

    public void StartDialog(string name)
    {
        if (!dialoguesManager)
        {
            dialoguesManager = GameObject.Find("Dialogue_Manager");
        }
        goNpc_name = name;
        Fill_text();
        OnOffDialogue(true);
    }



    public void ClickMouse()
    {

        if (Input.GetMouseButtonDown(0))//mouse
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                string tag = hit.transform.gameObject.tag;
                if (tag == "NPC_TAG")
                {
                    if (!chld.gameObject.activeInHierarchy)
                    {
                        chld.gameObject.SetActive(true);
                    }
                    goNpc_name = hit.transform.gameObject.GetComponent<Npc_Dialog>().getNpcName();
                    Fill_text();
                    npc_selected = true;
                }

            }
        }
    }
}
