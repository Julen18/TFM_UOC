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
    [UnityEngine.Tooltip("If we are going to kill player")]
    public SharedBool isGoingToKillPlayer;
    private EnemyManager em;

    public override void OnStart()
    {
        em = GetComponent<EnemyManager>();
    }

    public override TaskStatus OnUpdate()
    {
        returnedTransform.Value = em.IsInRange(targetTag.Value);
        if (returnedTransform.Value != null)
        {
            isGoingToKillPlayer.Value = true;
            // Return success if an object was found
            return TaskStatus.Success;
        }
        isGoingToKillPlayer.Value = false;
        // An object is not within sight so return failure
        return TaskStatus.Failure;
    }
}
