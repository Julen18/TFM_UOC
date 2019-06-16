using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;

public class InRangeByTag : Conditional
{
    [Tooltip("The object that we are searching for")]
    public SharedString targetTag;
    [Tooltip("The object that is within sight")]
    public SharedTransform returnedTransform;
    [Tooltip("If we are going to kill player")]
    public SharedBool isGoingToKillPlayer;

    private EnemyManager em;

    public override void OnStart()
    {
        em = GetComponent<EnemyManager>();
    }

    public override TaskStatus OnUpdate()
    {
        List<GameObject> players = em.IsInRange();
        foreach (GameObject obj in players)
        {
            PlayerStats ps = obj.GetComponent<PlayerStats>();
            if (ps != null)
            {
                if (ps.currentHealth > 0)
                {
                    returnedTransform.Value = obj.transform;
                    isGoingToKillPlayer.Value = true;
                    return TaskStatus.Success;
                }
            }
        }

        isGoingToKillPlayer.Value = false;
        return TaskStatus.Failure;
    }
}
