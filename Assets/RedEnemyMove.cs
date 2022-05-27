using UnityEngine;

public class RedEnemyMove : IRedEnemyAnimationState
{
    public void Idle(RedEnemyAnimationStateMachine stateMachine)
    {
        stateMachine.SetState(new RedEnemyIdle());
        stateMachine.animator.SetTrigger("Idle");
    }

    public void Move(RedEnemyAnimationStateMachine stateMachine){}
}
