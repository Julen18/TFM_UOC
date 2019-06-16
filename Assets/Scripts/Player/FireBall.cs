using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public AttacksPlayer ap;
    private float damange;
    public void SetAttacksPlayers(AttacksPlayer ap)
    {
        this.ap = ap;
    }

    public void SetDamage(float dmg)
    {
        damange = dmg;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ap.Dodamage(collision.gameObject,damange,true);

        Destroy(gameObject);
    }
}
