using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyAnimationStateMachine : MonoBehaviour
{
    //cache
    EnemyFollowTarget enemyFollowTarget;
    public Animator animator { get; private set; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyFollowTarget = GetComponent<EnemyFollowTarget>();
    }


    private void OnEnable()
    {
        enemyFollowTarget.OnEnemyMoving += Move;
        enemyFollowTarget.OnEnemyStopped += Idle;
    }

    private void OnDisable()
    {
        enemyFollowTarget.OnEnemyMoving -= Move;
        enemyFollowTarget.OnEnemyStopped -= Idle;
    }


    //state pattern
    IRedEnemyAnimationState currentAnimationState = new RedEnemyIdle();

    public void Move() => currentAnimationState.Move(this);
    public void Idle() => currentAnimationState.Idle(this);

    public void SetState(IRedEnemyAnimationState newState)
    {
        currentAnimationState = newState;
    }
}