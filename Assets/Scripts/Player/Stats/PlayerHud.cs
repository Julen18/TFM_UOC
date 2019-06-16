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
        float h, mh;
        switch (goSelected.tag)
        {
            case ENEMY_TAG:
                h = goSelected.GetComponent<EnemyManager>().health;
                mh = goSelected.GetComponent<EnemyManager>().maxHealth;
                SetCanvasSelectionOn();
                SetHudSelection(h, mh);
                break;
            case PLAYER_TAG:
                h = goSelected.GetComponent<PlayerStats>().currentHealth;
                mh = goSelected.GetComponent<PlayerStats>().maxHealth;
                SetCanvasSelectionOn();
                SetHudSelection(h, mh);
                break;
        }
    }

    public void ModifyHud(float key, float value, float maxValue =0)
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
        }
    }

    private void WhatIHaveSelected(RaycastHit hit)
    {
        string tag = hit.transform.gameObject.tag;
        //Debug.Log(tag);
        if(tag == "" || tag == "Untagged" || hit.transform == transform)
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
    private void SetHudSelection(float h,float mh)
    {
        ModifyHud(LIFE_SELECTION_HUD,h,mh);
        SetHealthBarSelection(h,mh);
    }
    public void ClickMouse()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.green);
        //if (Input.GetMouseButtonDown(0))//mouse
        //{   
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
        //}
    }

    //Setters
    public void SetHealthBar()
    {
        healthNum.text = stats.currentHealth + "/" + stats.maxHealth;
    }
    public void SetManaBar()
    {
        manaNum.text = stats.currentMana + "/" + stats.maxMana;
    }

    public void SetHealthBarSelection(float h, float hm)
    {
        healthSelectionNum.text = h + "/" + hm;
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

