using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;

public class IsInFrontByTransform : Conditional
{
    [Tooltip("The object that we are searching for")]
    public SharedTransform targetTransform;
    [Tooltip("The field of view angle of the agent (in degrees)")]
    public SharedFloat maxDistance = 1.5f;
    [@Tooltip("If we are going to kill player")]
    public SharedBool isGoingToKillPlayer;
    public override TaskStatus OnUpdate()
    {
        if (isGoingToKillPlayer.Value)
        {
            if (IsInFront())
            {
                Debug.Log("Aqui estamos");
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }

    private bool IsInFront()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position + new Vector3(0, 1.5f, 0), transform.TransformDirection(Vector3.forward) * maxDistance.Value, Color.yellow);

        if (Physics.Raycast(transform.position + new Vector3(0, 1.5f, 0), transform.TransformDirection(Vector3.forward), out hit, maxDistance.Value))
        {
            Debug.Log("Did Hit");
            return true;
        }

        return false;
    }
}
