using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private AttacksPlayer ap;

    private void Start()
    {
        ap = GetComponentInParent<AttacksPlayer>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.isTrigger) ap.Dodamage(other.gameObject);
    }
    
}
