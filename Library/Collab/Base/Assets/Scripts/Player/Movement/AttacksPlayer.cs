using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AttacksPlayer : MonoBehaviour
{
    public GameObject weapon;
    public float damageBasic;
    public float damageSpecial1;
    public float damageSpecial2;
    public float damageSpecial3;
    public float damageSpecial4;
    public float manaSpecial1;
    public float manaSpecial2;
    public float manaSpecial3;
    public float manaSpecial4;
    public bool canAttack;

    private string specialAttackActived;
    private PlayerStats ps;
    private Animator anim;
    private List<GameObject> enemyesBeaten = new List<GameObject>();
    private float damage;
    private float manaNeeded;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ps = GetComponent<PlayerStats>();
        canAttack = true;
        specialAttackActived = "Attack 2";
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.IsOn) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            specialAttackActived = "2";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            specialAttackActived = "3";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            specialAttackActived = "4";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            specialAttackActived = "5";
        }

        if (canAttack)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (ps.currentHealth > 0)
                {
                    damage = damageBasic;
                    anim.SetTrigger("Attack 1");
                    canAttack = false;
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                switch (specialAttackActived)
                {
                    case "2":
                        damage = damageSpecial1;
                        manaNeeded = manaSpecial1;
                        break;
                    case "3":
                        damage = damageSpecial2;
                        manaNeeded = manaSpecial2;
                        break;
                    case "4":
                        damage = damageSpecial3;
                        manaNeeded = manaSpecial3;
                        break;
                    case "5":
                        damage = damageSpecial4;
                        manaNeeded = manaSpecial4;
                        break;
                }

                if (ps.currentHealth > 0 && ps.currentMana >= manaNeeded)
                {
                    ps.currentMana -= manaNeeded;
                    anim.SetTrigger("Attack " + specialAttackActived);
                    canAttack = false;
                }
            }
        }
    }

    public void StartToDoDamage()
    {
        weapon.GetComponent<Weapon>().enabled = true;
        weapon.GetComponent<BoxCollider>().enabled = true;
    }

    public void EndToDoDamage()
    {
        weapon.GetComponent<Weapon>().enabled = false;
        weapon.GetComponent<BoxCollider>().enabled = false;
        enemyesBeaten = new List<GameObject>();
    }

    public void EndOfAttack()
    {
        canAttack = true;
    }

    public void Dodamage(GameObject obj, float dmg = -1, bool ignoreList = false)
    {
        if (obj.tag == "Enemy")
        {
            if (!ignoreList)
            {
                if (!enemyesBeaten.Contains(obj))
                {
                    enemyesBeaten.Add(obj);
                    obj.GetComponent<EnemyManager>().TakeDamage(dmg == -1 ? damage : dmg);
                }
            }
            else
            {
                obj.GetComponent<EnemyManager>().TakeDamage(dmg == -1 ? damage : dmg);
            }

        }
    }

    public float GetDamage()
    {
        return damage;
    }
}
