using UnityEngine;

public class RedEnemyIdle : IRedEnemyAnimationState
{
    public void Idle(RedEnemyAnimationStateMachine stateMachine){}

    public void Move(RedEnemyAnimationStateMachine stateMachine)
    {
        stateMachine.SetState(new RedEnemyMove());
        stateMachine.animator.SetTrigger("Move");
    }
}
