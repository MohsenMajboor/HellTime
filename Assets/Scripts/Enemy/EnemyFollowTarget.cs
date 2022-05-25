using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowTarget : MonoBehaviour
{

    //parameters
    [SerializeField] private GameObject _destinationObject;

    //cache
    NavMeshAgent _navMeshAgent;


    //events
    public delegate void EnemyAtTargetEventHandler();
    public event EnemyAtTargetEventHandler OnEnemyAtTarget;

    public delegate void EnemyAwayFromTargetEventHandler();
    public event EnemyAwayFromTargetEventHandler OnEnemyAwayFromTarget;

    private void Awake() 
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    // Start is called before the first frame update
    private void Update()
    {
        _navMeshAgent.SetDestination(_destinationObject.transform.position);

        if (Vector3.Distance(transform.position, _destinationObject.transform.position) <= _navMeshAgent.stoppingDistance && OnEnemyAtTarget != null)
        {
            OnEnemyAtTarget();
        }
        else if(Vector3.Distance(transform.position, _destinationObject.transform.position) > _navMeshAgent.stoppingDistance && OnEnemyAwayFromTarget != null)
        {
            OnEnemyAwayFromTarget();            
        }
    }
}
