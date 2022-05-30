using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{

    public event Action onMostEnemiesDead;

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<EnemyRunFromPlayer>();
        if(enemy)
        {
            Destroy(enemy.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var enemy = other.gameObject.GetComponent<EnemyRunFromPlayer>();
        if (enemy)
        {
            Destroy(enemy.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var enemy = other.gameObject.GetComponent<EnemyRunFromPlayer>();
        if (enemy)
        {
            Destroy(enemy.gameObject);
        }
    }

    private void Update()
    {
        if (FindObjectsOfType<EnemyRunFromPlayer>().Length <= 5)
        {
            onMostEnemiesDead?.Invoke();
        }
    }
}

