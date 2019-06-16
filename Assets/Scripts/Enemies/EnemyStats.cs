using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public abstract class MainEnemyClass : GenericMethodsClass
{
    public float maxHealth = 100;
    [SyncVar]
    public float health = 100;
    public float maxMana = 80;
    [SyncVar]
    public float mana = 80;

    public override void OnStartClient()
    {

    }

}
