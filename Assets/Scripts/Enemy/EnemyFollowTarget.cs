using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowTarget : MonoBehaviour
{

    //parameters
    [SerializeField] private GameObject destinationObject;

    //cache
    NavMeshAgent navMeshAgent;

    //events
    public delegate void EnemyAtTargetEventHandler();
    public event EnemyAtTargetEventHandler OnEnemyAtTarget;

    public delegate void EnemyAwayFromTargetEventHandler();
    public event EnemyAwayFromTargetEventHandler OnEnemyAwayFromTarget;

    public event Action OnEnemyMoving;
    public event Action OnEnemyStopped;

    private void Awake() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    // Start is called before the first frame update
    private void Update()
    {
        navMeshAgent.SetDestination(destinationObject.transform.position);

        if (Vector3.Distance(transform.position, destinationObject.transform.position) <= navMeshAgent.stoppingDistance)
        {
            OnEnemyAtTarget?.Invoke();
        }
        else if(Vector3.Distance(transform.position, destinationObject.transform.position) > navMeshAgent.stoppingDistance)
        {
            OnEnemyAwayFromTarget?.Invoke();            
        }

        if(Vector3.Distance(destinationObject.transform.position, transform.position) > navMeshAgent.stoppingDistance * 1.1f)
        {
            OnEnemyMoving?.Invoke();
        }
        else
        {
            OnEnemyStopped?.Invoke();
        }
    }
}
