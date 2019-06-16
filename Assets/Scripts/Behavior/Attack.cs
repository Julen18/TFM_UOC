using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Attack : Action
{
    [UnityEngine.Tooltip("The GameObject to kill")]
    public SharedTransform target;
    [UnityEngine.Tooltip("The damange ")]
    public SharedFloat damange;
    [UnityEngine.Tooltip("The time between attacks")]
    public SharedFloat cooldown = 3;
    [UnityEngine.Tooltip("The animation")]
    public SharedString attackAnimation;
    [UnityEngine.Tooltip("The animation to cancel")]
    public SharedString resetAnimation;
    [UnityEngine.Tooltip("Next time to do attack")]
    public SharedFloat nextAttack;
    [UnityEngine.Tooltip("Next time to do attack")]
    public SharedBool isKillingPlayer;

    private Animator animator;
    
    public override void OnAwake()
    {
        animator = GetComponent<Animator>();
    }

    public override TaskStatus OnUpdate()
    {
        isKillingPlayer.Value = true;
        // The task is done waiting if the time waitDuration has elapsed since the task was started.
        if (nextAttack.Value < Time.time)
        {
            nextAttack.Value = Time.time + cooldown.Value;
            animator.SetTrigger(attackAnimation.Value);
            animator.ResetTrigger(resetAnimation.Value);
            
            return TaskStatus.Success;
        }
        // Otherwise we are still waiting.
        return TaskStatus.Failure;
    }

}
