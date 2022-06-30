using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    private NavMeshAgent _agentEnemy;

    [SerializeField] private Transform[] _patrolTargets;

    private int i;

    private void OnValidate()
    {
        if(_agentEnemy == null)
        {
            _agentEnemy = GetComponent<NavMeshAgent>();
        }
    }

    private void TargetUpdate()
    {
        i = Random.Range(0,_patrolTargets.Length);
    }

    private void EnemyMove()
    {
        if (_agentEnemy.transform.position == _agentEnemy.pathEndPosition)
        {
            TargetUpdate();
        }
        _agentEnemy.SetDestination(_patrolTargets[i].position);
    }

    private void Update()
    {
        EnemyMove();
    }

}
