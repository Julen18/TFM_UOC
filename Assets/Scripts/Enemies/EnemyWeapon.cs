using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private EnemyManager em;

    private void Start()
    {
        em = GetComponentInParent<EnemyManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        em.DoDamange(other.gameObject);
    }
}
