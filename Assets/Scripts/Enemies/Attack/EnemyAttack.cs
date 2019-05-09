using UnityEngine;


public class EnemyAttack : MainEnemyClass
{
    public int damage = 10;
    public int manaBurn = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.health = health - 5;
            this.mana = mana - 5;
            Attack(other);
        }
    }

    private void Attack(Collider other)
    {   
        if (other.GetComponent<PlayerStats>().IsPlayerAlive())
        {
            other.GetComponent<PlayerStats>().TakeDamage(5);
            other.GetComponent<PlayerStats>().TakeMana(10);
        }
        else{
            return;
        }
        
    }
}
