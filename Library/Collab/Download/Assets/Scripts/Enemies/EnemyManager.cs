using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;

public class EnemyManager : MainEnemyClass
{
    public float damange;
    public GameObject weapon;
    public ParticleSystem blood;

    private List<GameObject> inRange = new List<GameObject>();
    private List<GameObject> playersBeaten = new List<GameObject>();
    private Animator anim;
    private string zone;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") inRange.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") inRange.Remove(other.gameObject);
    }

    public List<GameObject> IsInRange()
    {
        return inRange;
    }

    public void StartToDoDamange()
    {
        weapon.GetComponent<EnemyWeapon>().enabled = true;
        weapon.GetComponent<BoxCollider>().enabled = true;
    }

    public void EndToDoDamange()
    {
        weapon.GetComponent<EnemyWeapon>().enabled = false;
        weapon.GetComponent<BoxCollider>().enabled = false;
        playersBeaten = new List<GameObject>();
    }

    public void DoDamange(GameObject obj)
    {
        if (obj.tag == "Player")
        {
            if (!playersBeaten.Contains(obj))
            {
                playersBeaten.Add(obj);
                obj.GetComponent<PlayerStats>().TakeDamage(damange);
            }
        }
    }

    public void SetZone(string z)
    {
        BehaviorTree bt = GetComponent<BehaviorTree>();
        bt.SetVariableValue("Zone", z);
        zone = z;
    }

    public void TakeDamage(float damage)
    {

            if (health > 0)
            {
                health -= damage;
                blood.Play();
                if (health <= 0)
                {
                    health = 0;
                    TurnOff();
                    anim.SetTrigger("Die");
                    GameObject.Find(zone).GetComponent<EnemyZoneManager>().CmdRemoveEnemy(gameObject);
                }
            }
    }

    public void TurnOff()
    {
        GetComponent<BehaviorTree>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }
}
