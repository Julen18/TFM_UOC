using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class InitVars : Action
{
    public SharedBool bool1;
    public SharedBool setToBool1;

    public override TaskStatus OnUpdate()
    {
        if (bool1 != null) bool1.Value = setToBool1.Value;
        return TaskStatus.Success;
    }

}
