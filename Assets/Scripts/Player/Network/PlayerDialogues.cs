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
    public GameObject ply;
    private GameObject auxTarget;

    public GameObject faux;

    // Start is called before the first frame update
    void Start()
    {
        dialoguesManager = GameObject.Find("Dialogue_Manager");
        chld.SetActive(false);
        faux.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && npc_selected)
        {
            Next_text();
        }
        DoAction();
        RayCastAction();

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
            auxTarget.GetComponent<Npc_Dialog>().NotlookAtPlayer();
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

    public void RayCastAction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10))
        {
            string tag = hit.transform.gameObject.tag;
            switch (tag)
            {
                case "NPC_TAG":
                    auxTarget = hit.transform.gameObject;
                    hit.transform.gameObject.GetComponent<Npc_Dialog>().ActiveFocus();
                    if (faux.active == false && chld.activeInHierarchy == false)
                    {
                        faux.SetActive(true);
                    }else if(chld.activeInHierarchy == true)
                    {
                        faux.SetActive(false);
                    }

                    
                    break;
                case "Untagged":
                    if(auxTarget)
                    {
                        auxTarget.transform.gameObject.GetComponent<Npc_Dialog>().RemoveFocus();
                        auxTarget = null;
                        faux.SetActive(false);
                    }
                    break;
            }
        }
        else
        {
            if (auxTarget)
            {
                auxTarget.transform.gameObject.GetComponent<Npc_Dialog>().RemoveFocus();
                auxTarget = null;
                faux.SetActive(false);
            }
        }


    }

    public void DoAction()
    {

        if (Input.GetButtonDown("ActionWithEnvironment"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10))
            {
                string tag = hit.transform.gameObject.tag;
                if (tag == "NPC_TAG")
                {
                    if (!chld.gameObject.activeInHierarchy)
                    {
                        chld.gameObject.SetActive(true);
                    }
                    goNpc_name = hit.transform.gameObject.GetComponent<Npc_Dialog>().getNpcName();
                    hit.transform.gameObject.GetComponent<Npc_Dialog>().lookAtPlayer(ply);
                    auxTarget = hit.transform.gameObject;
                    Fill_text();
                    npc_selected = true;
                }

            }
        }
    }
}
