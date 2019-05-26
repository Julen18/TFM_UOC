using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class DisableIfIsNotServer : Conditional
{
    public override void OnStart()
    {
        if (!NetworkServer.active)
        {
            gameObject.GetComponent<BehaviorTree>().enabled = false;
        }
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.Success;
    }
}
