using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private List<GameObject> inRange = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        inRange.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        inRange.Remove(other.gameObject);
    }

    public Transform IsInRange(string tag)
    {
        int i = 0;
        while (i < inRange.Count)
        {
            if (inRange[i].tag == tag) return inRange[i].transform;
            i++;
        }

        return null;
    }
}
