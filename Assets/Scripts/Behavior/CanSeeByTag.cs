using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;

public class CanSeeByTag : Conditional
{
    [Tooltip("The object that we are searching for")]
    public SharedString targetTag;
    [Tooltip("The field of view angle of the agent (in degrees)")]
    public SharedFloat fieldOfViewAngle = 90;
    [Tooltip("The distance that the agent can see")]
    public SharedFloat viewDistance = 1000;
    [Tooltip("The object that is within sight")]
    public SharedTransform returnedTransform;
    [Tooltip("If we are going to kill player")]
    public SharedBool isGoingToKillPlayer;

    /// <summary>
    /// Returns success if an object was found otherwise failure
    /// </summary>
    /// <returns></returns>
    public override TaskStatus OnUpdate()
    {
        returnedTransform.Value = WithinSight(targetTag.Value, fieldOfViewAngle.Value, viewDistance.Value);
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

    /// <summary>
    /// Determines if the targetObject is within sight of the transform.
    /// </summary>
    private Transform WithinSight(string targetTag, float fieldOfViewAngle, float viewDistance)
    {
        if (targetTag == "")
        {
            return null;
        }

        GameObject[] players = GameObject.FindGameObjectsWithTag(targetTag);
        for (int i = 0; players.Length > i; i++)
        {
            var direction = players[i].transform.position - transform.position;
            direction.y += 1.5f;
            var angle = Vector3.Angle(direction, transform.forward);
            if (direction.magnitude < viewDistance && angle < fieldOfViewAngle)
            {
                // The hit agent needs to be within view of the current agent
                if (LineOfSight(players[i]))
                {
                    return players[i].transform; // return the target object meaning it is within sight
                }
            }
        }
        
        return null;
    }

    /// <summary>
    /// Returns true if the target object is within the line of sight.
    /// </summary>
    private bool LineOfSight(GameObject targetObject)
    {
        RaycastHit hit;
        Debug.DrawLine(transform.position, targetObject.transform.position + new Vector3(0, 1.5f, 0), Color.green);
        if (Physics.Linecast(transform.position, targetObject.transform.position + new Vector3(0, 1.5f, 0), out hit))
        {
            if (hit.transform.IsChildOf(targetObject.transform) || targetObject.transform.IsChildOf(hit.transform))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Draws the line of sight representation
    /// </summary>
    public override void OnDrawGizmos()
    {
#if UNITY_EDITOR
        var oldColor = UnityEditor.Handles.color;
        var color = Color.yellow;
        color.a = 0.1f;
        UnityEditor.Handles.color = color;

        var halfFOV = fieldOfViewAngle.Value * 0.5f;
        var beginDirection = Quaternion.AngleAxis(-halfFOV, Vector3.up) * Owner.transform.forward;
        UnityEditor.Handles.DrawSolidArc(Owner.transform.position, Owner.transform.up, beginDirection, fieldOfViewAngle.Value, viewDistance.Value);

        UnityEditor.Handles.color = oldColor;
#endif
    }

}
