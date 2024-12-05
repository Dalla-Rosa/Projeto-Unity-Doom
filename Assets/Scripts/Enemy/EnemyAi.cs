using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    private EnemyAwareness enemyAwareness;
    private Transform playersTransform;
    private NavMeshAgent enemyNavMeshAgent;

    void Start()
    {
        
        enemyAwareness = GetComponent<EnemyAwareness>();
        playersTransform = FindFirstObjectByType<PlayerMovement>().transform;
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (enemyAwareness.isAggro)
        {
            enemyNavMeshAgent.SetDestination(playersTransform.position);
        }
        else
        {

            enemyNavMeshAgent.SetDestination(transform.position);

        }
    }
}

