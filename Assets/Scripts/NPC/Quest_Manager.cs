using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Manager : MonoBehaviour
{
    public string npc_name;
    protected int number_of_quests;
    protected int last_quest_done;//saves on a file to get it later.//
    public string rewards;

    protected string[] questTexts;
    protected string[] responseTexts;

    protected bool current_state;

    //public string 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected string getNpcName()
    {
        return npc_name;
    }


    protected void fillQuestText(string[] arr)
    {
        string[] array = arr;
        int num = 0;
        questTexts = new string[arr.Length];
        foreach (string text in array)
        {
            questTexts[num] = text;
            num++;
        }
    }

    protected void fillDoneQuestText(string[] arr)
    {
        int num = 0;
        responseTexts = new string[arr.Length];
        foreach (string text in arr)
        {
            responseTexts[num] = text;
            num++;
        }
    }

    public void getText(string type, int num)
    {
        switch (type)
        {
            case "QUEST":
            case "RESPONSE":break;
        }
    }

}
