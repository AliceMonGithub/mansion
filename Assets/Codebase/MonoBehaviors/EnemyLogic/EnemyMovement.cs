using Codebase.HeroLogic;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Codebase.EnemyLogic
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Transform[] _points;

        [Space]

        [SerializeField] private Enemy _enemy;

        private Transform _currentPoint;

        private Vector3 _movingPoint;
        private Action _onFinishAction;

        private bool _movingToPoint;

        private Hero Target => _enemy.Target;
        private EnemyState State => _enemy.State;

        private Transform UnderPoint => _enemy.UnderPoint;
        private NavMeshAgent Navigation => _enemy.Navigation;

        private void Update()
        {
            if(State == EnemyState.Chase)
            {
                ChaseTarget();
            }
            
            else if(State == EnemyState.Patrol)
            {
                UpdatePoint();
            }
        }

        private void OnEnable()
        {
            _enemy.EnemyBehavior.OnStateChanged += (state, oldState) =>
            {
                if (state == EnemyState.Chase)
                {
                    _movingToPoint = false;

                    StopCoroutine(MoveToPoint());
                }
            };
        }

        private void OnDisable()
        {
            _enemy.EnemyBehavior.OnStateChanged -= (state, oldState) =>
            {
                if (state == EnemyState.Chase)
                {
                    _movingToPoint = false;

                    StopCoroutine(MoveToPoint());
                }
            };
        }

        public void SetMovingPoint(Vector3 movingPoint, Action onFinishAction = null)
        {
            _movingPoint = movingPoint;
            _onFinishAction = onFinishAction;

            StartCoroutine(MoveToPoint());
        }

        private IEnumerator MoveToPoint()
        {
            _movingToPoint = true;

            Navigation.SetDestination(_movingPoint);

            while(_enemy.UnderPoint.position != Navigation.pathEndPosition)
            {
                yield return null;
            }

            _movingToPoint = false;

            _onFinishAction?.Invoke();
        }

        private void UpdatePoint()
        {
            if (_movingToPoint) return;

            if (UnderPoint.position == Navigation.pathEndPosition)
            {
                _currentPoint = null;
            }

            if(_currentPoint == null)
            {
                SetRandomPoint();
            }

            Navigation.SetDestination(_currentPoint.position);
        }

        private void ChaseTarget()
        {
            Navigation.SetDestination(Target.CenterPoint.position);
        }

        private void SetRandomPoint()
        {
            _currentPoint = _points[UnityEngine.Random.Range(0, _points.Length)];
        }
    }
}