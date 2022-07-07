using Codebase.ExtensionPhysics;
using Codebase.HeroLogic;
using System.Collections;
using UnityEditor;
using UnityEngine;

namespace Codebase.EnemyLogic
{
    public enum EnemyState
    {
        Patrol,
        Chase
    }

    public class EnemyBehavior : MonoBehaviour
    {
        public event StateHandler OnStateChanged; 
        public delegate void StateHandler(EnemyState state, EnemyState oldPoint);

        public event EndPointHandler OnTargetMissed;
        public delegate void EndPointHandler(Vector3 endVisionPoint);

        [SerializeField] private float _fieldOfView;
        [SerializeField] private float _visionDistance;

        [Space]

        [SerializeField] private float _enemyMemory;

        [Space]

        [SerializeField] private Enemy _enemy;

        private EnemyState _state;

        private float _visionAngle;

        public EnemyState State => _state;

        private Hero Target => _enemy.Target;

        private Transform Transform => _enemy.Transform;
        private EnemyMovement EnemyMovement => _enemy.EnemyMovement;

        private void LateUpdate()
        {
            CheckVision();
        }

        private void OnDrawGizmosSelected()
        {
            Handles.color = Color.white;

            Handles.DrawWireArc(Transform.position, Vector3.up, Vector3.forward, 360, _visionDistance);

            Gizmos.color = Color.yellow;

            var direction = DirectionFromAngle(_visionAngle, Transform.eulerAngles.y);
            var negativeDirection = DirectionFromAngle(_visionAngle * -1, Transform.eulerAngles.y);

            Gizmos.DrawLine(Transform.position, Transform.position + direction * _visionDistance);
            Gizmos.DrawLine(Transform.position, Transform.position + negativeDirection * _visionDistance);

            if(_state == EnemyState.Chase)
            {
                Gizmos.color = Color.red;

                Gizmos.DrawLine(Transform.position, Target.CenterPoint.position);
            }
        }

        private void OnEnable()
        {
            OnStateChanged += (state, oldState) => StartCoroutine(TryPlaceEndPoint(state, oldState));
        }

        private void OnDisable()
        {
            OnStateChanged -= (state, oldState) => StartCoroutine(TryPlaceEndPoint(state, oldState));
        }

        private void OnValidate()
        {
            _visionAngle = _fieldOfView / 2;
        }

        private IEnumerator TryPlaceEndPoint(EnemyState state, EnemyState oldState)
        {
            if (state == EnemyState.Patrol && oldState == EnemyState.Chase)
            {
                OnTargetMissed?.Invoke(Target.UnderPoint.position);

                yield return new WaitForSeconds(_enemyMemory);

                EnemyMovement.UpdateEndPoint(Target.UnderPoint.position);
            }
        }

        private void CheckVision()
        {
            var direction = (Target.CenterPoint.position - Transform.position).normalized;
            var ray = new Ray(Transform.position, direction);

            if (Vector3.Angle(Transform.forward, direction) < _visionAngle)
            {
                if (ray.Raycast<Hero>(_visionDistance)) 
                {
                    OnStateChanged?.Invoke(EnemyState.Chase, _state);

                    _state = EnemyState.Chase;

                    return;
                }
            }

            OnStateChanged?.Invoke(EnemyState.Patrol, _state);

            _state = EnemyState.Patrol;
        }
        
        private Vector3 DirectionFromAngle(float angle, float YRotation = 0)
        {
            angle += YRotation;

            return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
        }
    }
}