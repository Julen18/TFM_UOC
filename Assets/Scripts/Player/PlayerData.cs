using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float health;
    public float mana;
    public float[] position;

    public string[,] npc;
    public string[,] qst;

    public PlayerData(PlayerStats ps)
    {
        health = ps.currentHealth;
        mana = ps.currentMana;

        position = new float[3];
        position[0] = ps.transform.position.x;
        position[1] = ps.transform.position.y;
        position[2] = ps.transform.position.z;

        GameObject npcs_quests = GameObject.Find ("NPCS_QUESTS");
        NpcQuest[] quests = npcs_quests.GetComponentsInChildren<NpcQuest>();
        npc = new string[quests.Length,5];
        int i = 0;
        foreach (NpcQuest quest in quests)
        {
            npc[i, 0] = quest.transform.position.x.ToString();
            npc[i, 1] = quest.transform.position.y.ToString();
            npc[i, 2] = quest.transform.position.z.ToString();
            npc[i, 3] = quest.colorActived;
            npc[i, 4] = quest.gameObject.activeSelf.ToString();

            i++;
        }

        GameObject quest_items = GameObject.Find("QuestItems");
        Transform[] qitems = quest_items.GetComponentsInChildren<Transform>();
        qst = new string[qitems.Length, 1];
        i = 0;
        foreach (Transform q_item in qitems)
        {
            qst[i, 0] = q_item.gameObject.activeSelf.ToString();

            i++;
        }

    }
}
