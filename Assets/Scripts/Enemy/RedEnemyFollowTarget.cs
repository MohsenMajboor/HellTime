using System;
using UnityEngine;
using UnityEngine.AI;

public class RedEnemyFollowTarget : MonoBehaviour
{

    //parameters
    [SerializeField] private GameObject _destinationObject;

    //cache
    NavMeshAgent navMeshAgent;


    //events
    public delegate void EnemyAtTargetEventHandler();
    public event EnemyAtTargetEventHandler OnEnemyAtTarget;

    public delegate void EnemyAwayFromTargetEventHandler();
    public event EnemyAwayFromTargetEventHandler OnEnemyAwayFromTarget;

    public event Action OnEnemyMoving;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    private void Update()
    {
        navMeshAgent.SetDestination(_destinationObject.transform.position);

        if (Vector3.Distance(transform.position, _destinationObject.transform.position) <= navMeshAgent.stoppingDistance)
        {
            OnEnemyAtTarget?.Invoke();
        }
        else if (Vector3.Distance(transform.position, _destinationObject.transform.position) > navMeshAgent.stoppingDistance)
        {
            OnEnemyAwayFromTarget?.Invoke();
        }

        if (navMeshAgent.velocity.magnitude > Mathf.Epsilon)
        {
            OnEnemyMoving?.Invoke();
        }
    }
}