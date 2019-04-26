using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerStats : MainPlayerClass
{
    [SyncVar (hook="OnChangeHealth")]
    public int currentHealth = 100;

    [SyncVar(hook = "OnChangeMana")]
    public int currentMana = 75;

    [SyncVar]
    public int maxMana = 75;//values of life and mana are temporally
    [SyncVar]
    public int maxHealth = 100;

    void Start()
    {
        this.GetComponent<PlayerHud>().SetBars();
    }

    void Update()
    {
        IsNotClient();
    }

    public void TakeDamage(int damage)
    {
        IsNotServer();
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                this.GetComponent<PlayerHud>().DeadScreen();//player is dead
            }
        }
        
    }
    public void TakeMana(int damage)
    {
        IsNotServer();
        currentMana -= damage;
    }

    void OnChangeHealth(int health)
    {
        this.GetComponent<PlayerHud>().ModifyHud(LIFE_HUD,health);
    }
    void OnChangeMana(int mana)
    {
        this.GetComponent<PlayerHud>().ModifyHud(MANA_HUD, mana);
    }

    public bool IsPlayerAlive()
    {
       return (currentHealth > 0) ? true : false;
        
    }


}
