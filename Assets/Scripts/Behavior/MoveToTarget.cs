using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class MoveToTarget : Action
{
    [UnityEngine.Tooltip("The speed of the agent")]
    public SharedFloat speed = 10;
    [UnityEngine.Tooltip("The angular speed of the agent")]
    public SharedFloat angularSpeed = 120;
    [UnityEngine.Tooltip("The agent has arrived when the destination is less than the specified amount. This distance should be greater than or equal to the NavMeshAgent StoppingDistance.")]
    public SharedFloat arriveDistance = 0.2f;
    [UnityEngine.Tooltip("The GameObject that the agent is seeking")]
    public SharedTransform target;
    [UnityEngine.Tooltip("Animation will run")]
    public SharedString anim;

    protected UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Animator animator;

    public override void OnAwake()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public override void OnStart()
    {
        navMeshAgent.speed = speed.Value;
        navMeshAgent.angularSpeed = angularSpeed.Value;
        navMeshAgent.isStopped = false;

        animator.SetTrigger(anim.Value);
        SetDestination(Target());
    }

    // Seek the destination. Return success once the agent has reached the destination.
    // Return running if the agent hasn't reached the destination yet
    public override TaskStatus OnUpdate()
    {
        if (target == null)
        {
            return TaskStatus.Failure;
        } else
        {
            SetDestination(Target());

            if (HasArrived())
            {
                Stop();
                return TaskStatus.Success;
            }
            return TaskStatus.Running;
        }
        
    }

    // Return targetPosition if target is null
    private Vector3 Target()
    {
        if (target.Value != null)
        {
            return target.Value.transform.position;
        }
        return Vector3.zero;
    }

    /// <summary>
    /// Set a new pathfinding destination.
    /// </summary>
    /// <param name="destination">The destination to set.</param>
    /// <returns>True if the destination is valid.</returns>
    private void SetDestination(Vector3 destination)
    {
        if (destination != Vector3.zero)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(destination);
        }
        else
        {
            Stop();
        }
    }

    /// <summary>
    /// Has the agent arrived at the destination?
    /// </summary>
    /// <returns>True if the agent has arrived at the destination.</returns>
    private bool HasArrived()
    {
        // The path hasn't been computed yet if the path is pending.
        float remainingDistance;
        if (navMeshAgent.pathPending)
        {
            remainingDistance = float.PositiveInfinity;
        }
        else
        {
            remainingDistance = navMeshAgent.remainingDistance;
        }

        return remainingDistance <= arriveDistance.Value;
    }

    /// <summary>
    /// Stop pathfinding.
    /// </summary>
    private void Stop()
    {
        if (navMeshAgent.hasPath)
        {
            navMeshAgent.isStopped = true;
        }
    }

    /// <summary>
    /// The task has ended. Stop moving.
    /// </summary>
    public override void OnEnd()
    {
        Stop();
    }

    /// <summary>
    /// The behavior tree has ended. Stop moving.
    /// </summary>
    public override void OnBehaviorComplete()
    {
        Stop();
    }
}
