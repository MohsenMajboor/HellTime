using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelfDestroyer : MonoBehaviour
{

    //cache
    EnemyHealth _enemyHealth;


    //events
    public delegate void EnemyDieEventHandler();
    public event EnemyDieEventHandler OnEnemyDie;

    private void Awake() 
    {
        _enemyHealth = GetComponent<EnemyHealth>();    
    }

    private void OnEnable() 
    {
        _enemyHealth.OnHealthZero += Die;
    }

    private void OnDisable() 
    {
        _enemyHealth.OnHealthZero -= Die;
    }

    private void Die()
    {
        Destroy(gameObject);
        if(OnEnemyDie != null) OnEnemyDie();
    }
}
