using Codebase.HeroLogic;
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

        private Vector3 _lastEndVisionPoint;

        private bool _movingToEndPoint;

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
            _enemy.EnemyBehavior.OnTargetMissed += (EndVisionPoint) =>
            {
                _lastEndVisionPoint = EndVisionPoint;

                StartCoroutine(MoveToEndPoint());
            };

            _enemy.EnemyBehavior.OnStateChanged += (state, oldState) =>
            {
                if (state == EnemyState.Chase)
                {
                    _movingToEndPoint = false;

                    StopCoroutine(MoveToEndPoint());
                }
            };
        }

        private void OnDisable()
        {
            _enemy.EnemyBehavior.OnTargetMissed -= (EndVisionPoint) =>
            {
                _lastEndVisionPoint = EndVisionPoint;

                StartCoroutine(MoveToEndPoint());
            };

            _enemy.EnemyBehavior.OnStateChanged -= (state, oldState) =>
            {
                if (state == EnemyState.Chase)
                {
                    _movingToEndPoint = false;

                    StopCoroutine(MoveToEndPoint());
                }
            };
        }

        private IEnumerator MoveToEndPoint()
        {
            _movingToEndPoint = true;

            Navigation.SetDestination(_lastEndVisionPoint);

            while(_enemy.UnderPoint.position != Navigation.pathEndPosition)
            {
                yield return null;
            }

            _movingToEndPoint = false;
        }

        public void UpdateEndPoint(Vector3 point)
        {
            _lastEndVisionPoint = point;

            Navigation.SetDestination(_lastEndVisionPoint);
        }

        private void UpdatePoint()
        {
            if (_movingToEndPoint) return;

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
            _currentPoint = _points[Random.Range(0, _points.Length)];
        }
    }
}