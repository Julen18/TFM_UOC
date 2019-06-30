using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerStats : MainPlayerClass
{
    public float currentHealth = 100;

    public float currentMana = 75;

    public float maxMana = 75;//values of life and mana are temporally
    public float maxHealth = 100;

    public Transform fireballSpawn;
    public GameObject fireballPrefab;
    public ParticleSystem blood;
    public RectTransform selectedSkill;
    public GameObject cam;

    [SerializeField]
    GameObject pauseMenu;
    public GameObject loading;

    private ThirdPersonUserControl thirdPersonUserControl;
    private Animator anim;
    private AttacksPlayer ap;

    void Start()
    {
        thirdPersonUserControl = GetComponent<ThirdPersonUserControl>();
        anim = GetComponent<Animator>();
        GetComponent<PlayerHud>().SetBars();
        ap = GetComponent<AttacksPlayer>();

        StartCoroutine("RegMana");
        StartCoroutine("RegHealth");

        PauseMenu.IsOn = false;
        PauseMenu.IsLoading = false;

        PlayerData data = SaveSystem.LoadPlayer();

        if (data != null)
        {
            currentHealth = data.health;
            currentMana = data.mana;
            transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);


            GameObject npcs_quests = GameObject.Find("NPCS_QUESTS");
            NpcQuest[] quests = npcs_quests.GetComponentsInChildren<NpcQuest>();
            int i = 0;
            foreach (NpcQuest quest in quests)
            {
                quest.transform.position = new Vector3(float.Parse(data.npc[i, 0]), float.Parse(data.npc[i, 1]), float.Parse(data.npc[i, 2]));
                quest.SetColorOfHalo(data.npc[i, 3]);
                quest.gameObject.SetActive(bool.Parse(data.npc[i, 4]));

                i++;
            }

            GameObject quest_items = GameObject.Find("QuestItems");
            Transform[] qitems = quest_items.GetComponentsInChildren<Transform>();
            i = 0;
            foreach (Transform q_item in qitems)
            {
                q_item.gameObject.SetActive(bool.Parse(data.qst[i, 0]));

                i++;
            }
        }

        cam.transform.SetParent(null);
        cam.SetActive(true);
    }

    private void Update()
    {
        if (currentHealth > 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !PauseMenu.IsLoading)
            {
                TogglePauseMenu();
            }

            if (PauseMenu.IsOn) return;

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedSkill.localPosition = new Vector3(-90, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                selectedSkill.localPosition = new Vector3(-30, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                selectedSkill.localPosition = new Vector3(30, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                selectedSkill.localPosition = new Vector3(90, 0, 0);
            }
        }
    }

    public void SavePlayer()
    {
        if (!PauseMenu.IsLoading) SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        if (!PauseMenu.IsLoading)
        {
            PauseMenu.IsLoading = true;
            SceneManager.LoadSceneAsync("Stage_I");
        }
    }

    private void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        PauseMenu.IsOn = pauseMenu.activeSelf;

        Cursor.lockState = pauseMenu.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = pauseMenu.activeSelf;
    }

    private IEnumerator RegHealth()
    {
        while (true)
        {
            TakeDamage(-1);

            yield return new WaitForSeconds(1.5f);
        }
    }

    private IEnumerator RegMana()
    {
        while (true)
        {
            TakeMana(-1);

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void TakeDamage(float damage)
    {

        OnChangeHealth();
        if (currentHealth > 0)
        {
            currentHealth = currentHealth - damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                anim.SetTrigger("Dead");
                thirdPersonUserControl.enabled = false;
                this.GetComponent<PlayerHud>().DeadScreen();//player is dead

                Invoke("Menu", 2f);
            }
            else if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            if (damage > 0) blood.Play();
        }
    }
    public void TakeMana(float damage)
    {
        OnChangeMana();
        currentMana -= damage;
        if (currentMana < 0)
        {
            currentMana = 0;
        }
        else if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
    }

    void OnChangeHealth()
    {
        this.GetComponent<PlayerHud>().ModifyHud(LIFE_HUD, currentHealth);
    }
    void OnChangeMana()
    {
        this.GetComponent<PlayerHud>().ModifyHud(MANA_HUD, currentMana);
    }

    public bool IsPlayerAlive()
    {
        return (currentHealth > 0) ? true : false;

    }

    private void Menu()
    {
        pauseMenu.SetActive(true);
        PauseMenu.IsOn = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    public void CmdFire()
    {
        GameObject fireball = (GameObject)Instantiate(fireballPrefab, fireballSpawn.position, fireballSpawn.rotation);
        fireball.GetComponent<Rigidbody>().velocity = fireball.transform.forward * 6;

        fireball.SendMessage("SetAttacksPlayers", ap);
        fireball.SendMessage("SetDamage", ap.GetDamage());
        Destroy(fireball, 4.0f);
    }
}
