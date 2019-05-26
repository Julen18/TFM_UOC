using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Tooltip = BehaviorDesigner.Runtime.Tasks.TooltipAttribute;

public class NextWayPointTarget : Action
{

    [@Tooltip("Returned transform of the next target")]
    public SharedTransform target;
    [@Tooltip("The zone")]
    public SharedInt lastWayPoint;
    [@Tooltip("The zone")]
    public SharedString zone;
    [@Tooltip("If we are going to kill player")]
    public SharedBool isGoingToKillPlayer;

    private WayPointsManager wpManager;

    public override void OnStart()
    {
        wpManager = GameObject.Find("ManagerEnemies" + zone).GetComponent<WayPointsManager>();
    }

    public override TaskStatus OnUpdate()
    {
        if (isGoingToKillPlayer.Value)
        {
            return TaskStatus.Failure;
        } else
        {
            NextWayPoint wp = wpManager.GetNextWayPoint(transform, lastWayPoint.Value);
            target.Value = wp.nextPoint;
            lastWayPoint.Value = wp.idNextWaypoint;
            return TaskStatus.Success;
        }
    }
}
