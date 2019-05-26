using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerHud : MainPlayerClass
{
    public Slider healthBar;
    public Text healthNum;
    public Slider manaBar;
    public Text manaNum;

    public Slider healthSelectionBar;
    public Text healthSelectionNum;
    public Slider manaSelectionBar;
    public Text manaSelectionNum;
    public GameObject selectionCanvas;

    public GameObject screenDead;
    public LayerMask layer;
    private PlayerStats stats;
    
    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
        SetCanvasSelectionOff();
        screenDead.SetActive(false);
        layer = ~layer;
    }
    void Update()
    {
        ClickMouse();
        if (HasSelection())
        {
            UpdateHudSelected();
        }
        
    }

    private void UpdateHudSelected()
    {
        switch (goSelected.tag)
        {
            case ENEMY_TAG:
                int h = goSelected.GetComponent<MainEnemyClass>().health;
                int m = goSelected.GetComponent<MainEnemyClass>().mana;
                int mh = goSelected.GetComponent<MainEnemyClass>().maxHealth;
                int mm = goSelected.GetComponent<MainEnemyClass>().maxMana;
                SetCanvasSelectionOn();
                SetHudSelection(h, m, mh, mm);
                break;
            case GAMECONTROLLER_TAG:
                break;
            case PLAYER_TAG:
                int h2 = goSelected.GetComponent<PlayerStats>().currentHealth;
                int m2 = goSelected.GetComponent<PlayerStats>().currentMana;
                int mh2 = goSelected.GetComponent<PlayerStats>().maxHealth;
                int mm2 = goSelected.GetComponent<PlayerStats>().maxMana;
                SetCanvasSelectionOn();
                SetHudSelection(h2, m2, mh2, mm2);
                break;
            default:
                break;
                //nothing
        }
    }

    public void ModifyHud(int key, int value,int maxValue=0)
    {
        switch (key)
        {
            case LIFE_HUD:
                healthBar.value = value;
                SetHealthBar();
                break;
            case MANA_HUD:
                manaBar.value = value;
                SetManaBar();
                break;
            case LIFE_SELECTION_HUD:
                healthSelectionBar.value = value;
                healthSelectionBar.maxValue = maxValue;
                break;
            case MANA_SELECTION_HUD:
                manaSelectionBar.value = value;
                manaSelectionBar.maxValue = maxValue;
                break;
        }
    }

    private void WhatIHaveSelected(RaycastHit hit)
    {
        string tag = hit.transform.gameObject.tag;
        //Debug.Log(tag);
        if(tag == "" || tag == "Untagged")
        {
            if (HasSelection())
            {
                SetCanvasSelectionOff();
            }
            return;
        }
        GameObject go = hit.transform.gameObject;
        SetSelectionToTrue(go);
        UpdateHudSelected();
    }

    public void SetBars()
    {
        SetHealthBar();
        SetManaBar();
    }
    private void SetHudSelection(int h, int m, int mh, int mm)
    {
        ModifyHud(LIFE_SELECTION_HUD,h,mh);
        ModifyHud(MANA_SELECTION_HUD,m,mm);
        SetManaBarSelection(m,mm);
        SetHealthBarSelection(h,mh);
    }
    public void ClickMouse()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green);
        if (Input.GetMouseButtonDown(0))//mouse
        {   
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, layer))
            {
                WhatIHaveSelected(hit);
            }
            else
            {
                SetCanvasSelectionOff();
            }
        }
    }

    //Setters
    public void SetHealthBar()
    {
        healthNum.text = stats.currentHealth + "/" + stats.maxHealth;
    }
    public void SetManaBar()
    {
        manaNum.text = stats.currentHealth + "/" + stats.maxMana;
    }

    public void SetHealthBarSelection(int h, int hm)
    {
        healthSelectionNum.text = h + "/" + hm;
    }
    public void SetManaBarSelection(int m, int mm)
    {
        manaSelectionNum.text = m + "/" + mm;
    }

    public void SetCanvasSelectionOn()
    {
        this.selectionCanvas.SetActive(true);
    }
    public void SetCanvasSelectionOff()
    {
        this.selectionCanvas.SetActive(false);
        SetSelectionToFalse();
    }

    public void DeadScreen()
    {
        this.screenDead.SetActive(true);
    }
}

