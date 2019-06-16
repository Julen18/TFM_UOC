using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;

public class PlayerQuest : MonoBehaviour
{
    public Text main_text;
    private bool npc_selected;
    public GameObject target;

    public Button accept;
    public Button decline;

    public GameObject chld;
    private GameObject cam;
    private GameObject auxGo;
    public GameObject faux;
    public GameObject ply;
    private GameObject auxTarget;
    // Start is called before the first frame update
    void Start()
    {
        accept.onClick.AddListener(delegate { ButtonFunction("Accept"); });
        decline.onClick.AddListener(delegate { ButtonFunction("Decline"); });
        chld.SetActive(false);
        cam = GameObject.Find("FreeLookCameraRig");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && npc_selected)
        {
           // Fill_text();
        }
        DoAction();
        RayCastAction(); 
    }
    void Fill_text()
    {
        main_text.text = target.GetComponentInChildren<NpcQuest>().GetText();
        cam.GetComponent<FreeLookCam>().LockPj(true);
        ply.GetComponent<AttacksPlayer>().canAttack = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

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
                case "NPC_QUEST":
                    auxTarget = hit.transform.gameObject;
                    if (faux.active == false && chld.activeInHierarchy == false)
                    {
                        faux.SetActive(true);
                    }
                    else if (chld.activeInHierarchy == true)
                    {
                        faux.SetActive(false);
                    }


                    break;
                case "Untagged":
                    if (auxTarget)
                    {
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

            if (Physics.Raycast(ray, out hit, 100))
            {
                string tag = hit.transform.gameObject.tag;
                if (tag == "NPC_QUEST")
                {
                    if (!chld.gameObject.activeInHierarchy)
                    {
                        chld.gameObject.SetActive(true);
                    }
                    target = hit.transform.gameObject;
                    hit.transform.gameObject.GetComponent<NpcQuest>().lookAtPlayer(ply);
                    auxTarget = hit.transform.gameObject;
                    Fill_text();
                    npc_selected = true;
                }

            }
        }
    }

    private void ButtonFunction(string type)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cam.GetComponent<FreeLookCam>().LockPj(false);//pass to a function
        switch (type)
        {
            case "Accept":
                target.GetComponent<NpcQuest>().StartMision();
                break;
            case "Decline":

                break;
        }
        ply.GetComponent<AttacksPlayer>().canAttack = true;
        npc_selected = false;
        chld.gameObject.SetActive(false);

    }


   


}
