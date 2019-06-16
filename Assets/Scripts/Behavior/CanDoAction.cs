using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;

public class CanDoAction : Conditional
{
    [Tooltip("The bool to check")]
    public SharedBool boolToCheck;
    [Tooltip("If the bool is true return failure")]
    public SharedBool trueIsFalse;

    public override TaskStatus OnUpdate()
    {
        if (trueIsFalse.Value)
        {
            if (boolToCheck.Value)
            {
                return TaskStatus.Failure;
            } else
            {
                return TaskStatus.Success;
            }
        } else
        {
            if (boolToCheck.Value)
            {
                return TaskStatus.Success;
            }
            else
            {
                return TaskStatus.Failure;
            }
        }
    }
}
