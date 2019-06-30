using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MainPlayerClass : GenericMethodsClass
{
    //HUD CONSTANTS

    public const int LIFE_HUD = 1;
    public const int MANA_HUD = 2;
    public const int EXPERIENCE_HUD = 3;
    public const int LEVEL_HUD = 4;
    public const int LIFE_SELECTION_HUD = 5;


    public const string GAMECONTROLLER_TAG = "GameController";
    public const string ENEMY_TAG = "Enemy";
    public const string PLAYER_TAG = "Player";
    public const string NPC_TAG = "NPC_TAG";

    protected bool selection = false;
    protected GameObject goSelected = null;
    public bool HasSelection()
    {
        return selection;
    }

    public void SetSelectionToTrue(GameObject go)
    {
        selection = true;
        goSelected = go;
    }
    public void SetSelectionToFalse()
    {
        selection = false;
        goSelected = null;
    }


}
