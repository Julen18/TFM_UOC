using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcQuest : Quest_Manager
{
    public string nameOfChar;
    public GameObject dialoguesManager;
    /* public string npc_name;
    public int number_of_quests;
    public int last_quest_done;//saves on a file to get it later.//
    public string rewards;

    public string[] questTexts;
    public string[] responseTexts;*/
    // Start is called before the first frame update
    public enum MyEnumeratedType
    {
        isQuestTokill, isQuestToCollect, isQuestToTalk, isQuestInstantiate
    }
    public MyEnumeratedType option;
    public GameObject particles;

    public GameObject[] goToInstantiate;
    void Start()
    {
        dialoguesManager = GameObject.Find("Dialogue_Manager");
        //fillTextQuest();
        //number_of_quests = questTexts.Length;
        last_quest_done = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string GetText()
    {
        //switch case con devolver pregunta mision, o respuesta
        fillTextQuest();
        return this.questTexts[last_quest_done];

    }

    private void fillTextQuest()
    {
        if (!dialoguesManager)
        {
            dialoguesManager = GameObject.Find("Dialogue_Manager");
        }
        //dialoguesManager.GetComponent<Dialogues>().GetDictionary(this.getNpcName());
        fillQuestText(dialoguesManager.GetComponent<Dialogues>().GetDictionary(this.getNpcName()).ToArray()); 
        fillDoneQuestText(dialoguesManager.GetComponent<Dialogues>().GetDictionary(this.getNpcName()+"R").ToArray());

    }


    public void StartMision()
    {
        current_state = true;

        switch (option)
        {
            case MyEnumeratedType.isQuestInstantiate:
                StartInstantiateQuest(last_quest_done);
                break;
            case MyEnumeratedType.isQuestToCollect:
                break;
            case MyEnumeratedType.isQuestTokill:
                break;
            case MyEnumeratedType.isQuestToTalk:
                break;
        }
    }

    public void EndMision()
    {
        current_state = false;
    }

    private void StartInstantiateQuest(int numOfQuest)
    {
        string[] arr = dialoguesManager.GetComponent<Dialogues>().GetDictionary(this.getNpcName()+"I").ToArray();
        for(int i = 0, j=1, y=2; y<arr.Length;)
        {
        GameObject go = Instantiate(this.goToInstantiate[numOfQuest]);
            go.transform.position = new Vector3(float.Parse(arr[i].ToString()), float.Parse(arr[j].ToString()), float.Parse(arr[y].ToString()));
            Instantiate(this.particles, go.transform.position,go.transform.rotation);
            i = i +3;
            j = j + 3;
            y = y + 3;

            //se setea un tag de "item_quest_nameOfQuest", cuando el jugador lo detecta, mira a que mision pertenece y suma lo pertinente en el script 
        }
    //new Vector3(float.Parse(arr[i].ToString()), float.Parse(arr[j].ToString()), float.Parse(arr[y].ToString())

    }
}
