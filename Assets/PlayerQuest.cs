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
            Fill_text();
        }
        ClickMouse();
    }
    void Fill_text()
    {
        main_text.text = target.GetComponentInChildren<NpcQuest>().GetText();
        cam.GetComponent<FreeLookCam>().LockPj(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

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
                if (tag == "NPC_QUEST")
                {
                    if (!chld.gameObject.activeInHierarchy)
                    {
                        chld.gameObject.SetActive(true);
                    }
                    target = hit.transform.gameObject;
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
        npc_selected = false;
        chld.gameObject.SetActive(false);

    }


}
