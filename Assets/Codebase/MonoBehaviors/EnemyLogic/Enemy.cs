using Codebase.HeroLogic;
using UnityEngine;
using UnityEngine.AI;

namespace Codebase.EnemyLogic
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Hero _target;
        [SerializeField] private Transform _underPoint;

        [Space]

        [SerializeField] private EnemyBehavior _enemyBehavior;
        [SerializeField] private EnemyMovement _enemyMovement;

        [Space]

        [SerializeField] private Transform _transform;
        [SerializeField] private NavMeshAgent _navigation;

        public Hero Target => _target;
        
        public EnemyState State => _enemyBehavior.State;

        public Transform UnderPoint => _underPoint;

        public Transform Transform => _transform;
        public NavMeshAgent Navigation => _navigation;

        public EnemyBehavior EnemyBehavior => _enemyBehavior;
        public EnemyMovement EnemyMovement => _enemyMovement;

        private void OnValidate()
        {
            if(_target == null)
            {
                _target = FindObjectOfType<Hero>();
            }

            if(EnemyBehavior == null)
            {
                _enemyBehavior = GetComponent<EnemyBehavior>();
            }

            if(_enemyMovement == null)
            {
                _enemyMovement = GetComponent<EnemyMovement>();
            }

            if (_navigation == null)
            {
                _navigation = GetComponent<NavMeshAgent>();
            }

            if (_transform == null)
            {
                _transform = transform;
            }
        }
    }
}