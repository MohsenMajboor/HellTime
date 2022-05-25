using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    //cache
    Animator _animator;
    EnemyFollowTarget _enemyFollowTarget;

    private void Awake() 
    {
        _animator = GetComponent<Animator>();    
        _enemyFollowTarget = GetComponentInParent<EnemyFollowTarget>();
    }

    private void OnEnable() 
    {
        _enemyFollowTarget.OnEnemyAtTarget += PlayAttack;
        _enemyFollowTarget.OnEnemyAwayFromTarget += PlayRunning;
    }

    private void OnDisable() 
    {
        _enemyFollowTarget.OnEnemyAtTarget -= PlayAttack;
        _enemyFollowTarget.OnEnemyAwayFromTarget -= PlayRunning;
    }

    private void PlayRunning()
    {
        _animator.Play("Running");
    }

    private void PlayAttack()
    {
        _animator.Play("Attack");
    }
}
