using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcQuest : Quest_Manager
{
    public string nameOfChar;
    public GameObject dialoguesManager;
    private bool lookAtPl;
    private GameObject target;

    public GameObject yellow;
    public GameObject blue;
    public GameObject green;

    private int numOfQuestPrivate;
    private int numOfItemsPrivate;
    public bool flagToDo;

    public GameObject enemyManager;

    public string colorActived;

    private enum MyStateOfQuest
    {
        haveQuests, questOnProgress, questDone, noMoreQuests
    }

    private MyStateOfQuest stateOfQuest;

    public enum MyEnumeratedType
    {
        isQuestTokill, isQuestToCollect, isQuestToTalk, isQuestInstantiate, specialQuest
    }

    public MyEnumeratedType option;
    public GameObject particles;

    public GameObject[] goToInstantiate;
    public GameObject[] goToActivate;
    public GameObject[] goToDesactivate;
    public GameObject[] goToActivatePersistents;
    public string[] itemsForPlayerInv;

    void Start()
    {

        numOfQuestPrivate = 0;//modifyc
        numOfItemsPrivate = 0;
        dialoguesManager = GameObject.Find("Dialogue_Manager");
        if (dialoguesManager)
        {
            try
            {
                fillQuestText(dialoguesManager.GetComponent<Dialogues>().GetDictionary(this.getNpcName()).ToArray());
                fillDoneQuestText(dialoguesManager.GetComponent<Dialogues>().GetDictionary(this.getNpcName() + "R").ToArray());
            }
            catch (Exception ex)
            {

            }
        }
        //number_of_quests = questTexts.Length;
        last_quest_done = 0;
        stateOfQuest = MyStateOfQuest.haveQuests;


        if (stateOfQuest == MyStateOfQuest.haveQuests)
        {
            SetColorOfHalo(YELLOW_COLOR);
        }
        else if (stateOfQuest == MyStateOfQuest.noMoreQuests)
        {
            SetColorOfHalo(GREEN_COLOR);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (lookAtPl)
        {
            Vector3 relativePos = target.transform.position - this.transform.position;
            Quaternion newRotation = Quaternion.LookRotation(relativePos, Vector3.up);
            this.transform.rotation = new Quaternion(this.transform.rotation.x, newRotation.y, this.transform.rotation.x, this.transform.rotation.w);

        }
    }



    private void fillTextQuest()
    {
        if (!dialoguesManager)
        {
            dialoguesManager = GameObject.Find("Dialogue_Manager");

        }

        if (dialoguesManager)
        {
            fillQuestText(dialoguesManager.GetComponent<Dialogues>().GetDictionary(this.getNpcName()).ToArray());
            fillDoneQuestText(dialoguesManager.GetComponent<Dialogues>().GetDictionary(this.getNpcName() + "R").ToArray());
        }

    }

    private void StartActiveItemForCollect()
    {
        foreach (GameObject g in goToInstantiate)//named instantiate but are go to active
        {
            g.SetActive(true);
            g.AddComponent<BoxCollider>();
            g.GetComponent<BoxCollider>().isTrigger = true;
            g.AddComponent<ItemsQuest>();
            g.GetComponent<ItemsQuest>().SetIsQuest(true);
            g.GetComponent<ItemsQuest>().ObjNoDestroy();
            g.GetComponent<ItemsQuest>().SetName(goToInstantiate.ToString());

            GameObject goParticles = Instantiate(this.particles, g.transform.position, g.transform.rotation);
            goParticles.transform.parent = g.transform;

        }
        numOfItemsPrivate = goToInstantiate.Length;
    }
    private void StartActiveItemPersist()
    {
        foreach (GameObject g in goToActivatePersistents)
        {
            g.SetActive(true);
        }
    }
    private void ActiveAndDeactiveArray()
    {
        foreach (GameObject g in goToActivate)
        {
            g.SetActive(true);
        }
        foreach (GameObject g in goToDesactivate)
        {
            g.SetActive(false);
        }
    }
    private void StartInstantiateQuest(int numOfQuest)
    {
        this.stateOfQuest = MyStateOfQuest.questOnProgress;
        string[] arr = dialoguesManager.GetComponent<Dialogues>().GetDictionary(this.getNpcName() + "I").ToArray();
        for (int i = 0, j = 1, y = 2; y < arr.Length;)
        {
            GameObject go = Instantiate(this.goToInstantiate[numOfQuest]);

            go.transform.position = new Vector3(float.Parse(arr[i].ToString()), float.Parse(arr[j].ToString()), float.Parse(arr[y].ToString()));
            go.AddComponent<BoxCollider>();
            go.GetComponent<BoxCollider>().isTrigger = true;
            go.AddComponent<ItemsQuest>();
            go.GetComponent<ItemsQuest>().SetIsQuest(true);
            go.GetComponent<ItemsQuest>().SetName(goToInstantiate.ToString());

            GameObject goParticles = Instantiate(this.particles, go.transform.position, go.transform.rotation);
            goParticles.transform.parent = go.transform;
            i = i + 3;
            j = j + 3;
            y = y + 3;
            //se setea un tag de "item_quest_nameOfQuest", cuando el jugador lo detecta, mira a que mision pertenece y suma lo pertinente en el script 
        }
        target.gameObject.GetComponentInChildren<CanvasItemsUIQuest>().SetText(this.goToInstantiate[numOfQuest].name);
        target.gameObject.GetComponentInChildren<CanvasItemsUIQuest>().SetTotal((arr.Length / 3));
        numOfQuestPrivate = numOfQuest;
        numOfItemsPrivate = arr.Length / 3;

    }

    private void GivePlayerItem()
    {
        for (int i = 0; i < itemsForPlayerInv.Length; i++)
        {
            target.GetComponentInChildren<InventoryPlayer>().PutItemInInventorySpecial(itemsForPlayerInv[i]);
        }
    }
    public void StartMision()
    {
        if (this.stateOfQuest == MyStateOfQuest.questOnProgress || this.stateOfQuest == MyStateOfQuest.questDone)
        {
            return;
        }
        current_state = true;
        this.stateOfQuest = MyStateOfQuest.questOnProgress;
        SetColorOfHalo(BLUE_COLOR);

        switch (option)
        {
            case MyEnumeratedType.isQuestInstantiate:
                StartInstantiateQuest(last_quest_done);
                break;
            case MyEnumeratedType.isQuestToCollect:
                GivePlayerItem();
                StartActiveItemPersist();
                StartActiveItemForCollect();
                break;
            case MyEnumeratedType.isQuestTokill:
                ActiveAndDeactiveArray();
                enemyManager.GetComponent<EnemyZoneManager>().StartToSpawn();
                enemyManager.GetComponent<EnemyZoneManager>().StopToSpawn();
                break;
            case MyEnumeratedType.isQuestToTalk:
                StartActiveItemPersist();
                GivePlayerItem();
                break;
            case MyEnumeratedType.specialQuest:
                goToActivate[0].GetComponent<SpecialScript>().DoSomething();

                break;
        }
    }


    public string GetText()
    {
        CheckInfo();

        if (last_quest_done >= this.questTexts.Length)
        {
            return "NONE";
        }

        if (this.stateOfQuest == MyStateOfQuest.questOnProgress)
        {
            return " Ya estás en esta misión";
        }
        else if (this.stateOfQuest == MyStateOfQuest.questDone)
        {
            string beforesum = this.responseTexts[last_quest_done];
            if (last_quest_done + 1 < this.questTexts.Length)//si se sale es que no hay más, no se suma y se deja siempre la respuesta.
            {
                last_quest_done++;
                this.stateOfQuest = MyStateOfQuest.haveQuests;//hay más misioneS
            }
            else
            {
                CheckNextQuestOnOtherGO();
            }
            return beforesum;

            //si está hecha, mirar texto respuesta o si tiene más, darla.
        }
        return this.questTexts[last_quest_done];

    }


    private void CheckInfo()
    {
        //En que punto de la quest estoy
        //Modificar color a verde si acabada, amarilla si hay mas, azul progreso

        switch (this.stateOfQuest)
        {
            case MyStateOfQuest.haveQuests:
                fillTextQuest();
                SetColorOfHalo(YELLOW_COLOR);
                break;
            case MyStateOfQuest.questDone:
            case MyStateOfQuest.noMoreQuests:
                SetColorOfHalo(GREEN_COLOR);
                break;
            case MyStateOfQuest.questOnProgress:

                switch (option)
                {
                    case MyEnumeratedType.isQuestInstantiate:
                        {
                            int n = target.GetComponentInChildren<InventoryPlayer>().GetCountItemFromInventoryQuest(this.goToInstantiate[numOfQuestPrivate].name);
                            //if (5 == numOfItemsPrivate)
                            if (n == numOfItemsPrivate)
                            {
                                this.stateOfQuest = MyStateOfQuest.questDone;
                                SetColorOfHalo(GREEN_COLOR);
                                target.gameObject.GetComponentInChildren<CanvasItemsUIQuest>().SetText("");
                            }
                        }
                        break;
                    case MyEnumeratedType.isQuestToCollect:
                        int n1 = target.GetComponentInChildren<InventoryPlayer>().GetCountItemFromInventoryQuest(this.goToInstantiate[numOfQuestPrivate].name);
                        //if (1 == 1)
                        if (n1 == numOfItemsPrivate)
                        {
                            this.stateOfQuest = MyStateOfQuest.questDone;
                            SetColorOfHalo(GREEN_COLOR);
                            ActiveAndDeactiveArray();
                            target.gameObject.GetComponentInChildren<CanvasItemsUIQuest>().SetText("");
                        }
                        break;
                    case MyEnumeratedType.isQuestToTalk:
                        {
                            SetColorOfHalo(GREEN_COLOR);
                            this.stateOfQuest = MyStateOfQuest.questDone;
                            target.gameObject.GetComponentInChildren<CanvasItemsUIQuest>().SetText("");
                            ActiveAndDeactiveArray();
                            if (flagToDo)
                            {
                                this.gameObject.SetActive(false);
                            }
                        }
                        break;
                    case MyEnumeratedType.isQuestTokill:
                        {
                            if (enemyManager.GetComponent<EnemyZoneManager>().TotallySpawns() == enemyManager.GetComponent<EnemyZoneManager>().TotallyKillSpawns())
                            {
                                SetColorOfHalo(GREEN_COLOR);
                                this.stateOfQuest = MyStateOfQuest.questDone;
                                target.gameObject.GetComponentInChildren<CanvasItemsUIQuest>().SetText("");
                            }
                        }
                        break;
                }
                break;
        }

    }

    public void SetColorOfHalo(string color)
    {
        colorActived = color;
        switch (color)
        {
            case YELLOW_COLOR:
                this.yellow.SetActive(true);
                this.green.SetActive(false);
                this.blue.SetActive(false);
                break;
            case BLUE_COLOR:
                this.yellow.SetActive(false);
                this.green.SetActive(false);
                this.blue.SetActive(true);
                break;
            case GREEN_COLOR:
                this.yellow.SetActive(false);
                this.green.SetActive(true);
                this.blue.SetActive(false);
                break;

        }
    }
    private void CheckNextQuestOnOtherGO()
    {
        //Look if this go activates another
        if (goToActivate.Length > 0)
        {
            goToActivate[0].SetActive(true);//acgtive next go
        }

    }
    public void lookAtPlayer(GameObject ply)
    {
        lookAtPl = true;
        target = ply;
    }
    public void NotlookAtPlayer()
    {
        lookAtPl = false;
    }


    public void EndMision()
    {
        current_state = false;

    }

}

