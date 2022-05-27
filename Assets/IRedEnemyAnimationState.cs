using UnityEngine;

public interface IRedEnemyAnimationState
{
    void Move(RedEnemyAnimationStateMachine stateMachine);
    void Idle(RedEnemyAnimationStateMachine stateMachine);
}
