using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerStats : MainPlayerClass
{
    [SyncVar(hook = "OnChangeHealth")]
    public float currentHealth = 100;

    [SyncVar(hook = "OnChangeMana")]
    public float currentMana = 75;

    [SyncVar]
    public float maxMana = 75;//values of life and mana are temporally
    [SyncVar]
    public float maxHealth = 100;

    public Transform fireballSpawn;
    public GameObject fireballPrefab;

    private ThirdPersonUserControl thirdPersonUserControl;
    private Animator anim;
    private AttacksPlayer ap;

    void Start()
    {
        thirdPersonUserControl = GetComponent<ThirdPersonUserControl>();
        anim = GetComponent<Animator>();
        GetComponent<PlayerHud>().SetBars();
        ap = GetComponent<AttacksPlayer>();
    }


    public void TakeDamage(float damage)
    {
        if (IsServer())
        {
            if (currentHealth > 0)
            {
                currentHealth = currentHealth - damage;
                if (currentHealth <= 0)
                {
                    currentHealth = 0;
                    anim.SetTrigger("Dead");
                    thirdPersonUserControl.enabled = false;
                    this.GetComponent<PlayerHud>().DeadScreen();//player is dead
                }
            }
        }

    }
    public void TakeMana(float damage)
    {
        if (IsServer())
        {
            currentMana -= damage;
        }
    }

    void OnChangeHealth(float health)
    {
        currentHealth = health;
        this.GetComponent<PlayerHud>().ModifyHud(LIFE_HUD, health);
    }
    void OnChangeMana(float mana)
    {
        currentMana = mana;//reasign needed
        this.GetComponent<PlayerHud>().ModifyHud(MANA_HUD, mana);
    }

    public bool IsPlayerAlive()
    {
        return (currentHealth > 0) ? true : false;

    }

    public override void OnStartClient()
    {

    }


    [Command]
    public void CmdFire()
    {
        GameObject fireball = (GameObject)Instantiate(fireballPrefab, fireballSpawn.position, fireballSpawn.rotation);
        fireball.GetComponent<Rigidbody>().velocity = fireball.transform.forward * 6;

        fireball.SendMessage("SetAttacksPlayers", ap);
        fireball.SendMessage("SetDamage", ap.GetDamage());
        NetworkServer.Spawn(fireball);
        Destroy(fireball, 2.0f);
    }
}
