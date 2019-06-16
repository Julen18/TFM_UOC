using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class LookAt : Action
{
    [UnityEngine.Tooltip("Target to look at")]
    public SharedTransform target;

    public override TaskStatus OnUpdate()
    {
        Vector3 relativePos = target.Value.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = new Quaternion(this.transform.rotation.x, newRotation.y, this.transform.rotation.x, this.transform.rotation.w);

        return TaskStatus.Success;
    }
}
