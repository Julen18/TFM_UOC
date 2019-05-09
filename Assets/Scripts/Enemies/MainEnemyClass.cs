using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public abstract class MainEnemyClass : GenericMethodsClass
{
    public int maxHealth = 100;
    [SyncVar]
    public int health = 100;
    public int maxMana = 80;
    [SyncVar]
    public int mana = 80;

    public override void OnStartClient()
    {

    }

}
