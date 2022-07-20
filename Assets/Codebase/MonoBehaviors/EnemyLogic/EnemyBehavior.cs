using Codebase.ExtensionPhysics;
using Codebase.HeroLogic;
using Codebase.Services.InteractService;
using System.Collections;
using UnityEditor;
using UnityEngine;

namespace Codebase.EnemyLogic
{
    public enum EnemyState
    {
        Patrol,
        Seek,
        Chase
    }

    public class EnemyBehavior : MonoBehaviour
    {
        public event StateHandler OnStateChanged; 
        public delegate void StateHandler(EnemyState state, EnemyState oldPoint);

        [Header("Vision")]
        [SerializeField] private float _fieldOfView;
        [SerializeField] private float _visionRange;

        [Space]

        [SerializeField] private float _enemyMemory;

        [Header("Interact")]

        [SerializeField] private Transform _rayPoint;

        [Space]

        [SerializeField] private float _rayDistance;

        [Header("Components")]
        [SerializeField] private Enemy _enemy;

        [SerializeField] private AudioSource _onChaseSound;
        [SerializeField] private AudioSource _chaseSound;
        [SerializeField] private EnemyState _state;

        private float _visionAngle;

        public EnemyState State => _state;

        private Hero Target => _enemy.Target;

        private Transform Transform => _enemy.Transform;
        private EnemyMovement EnemyMovement => _enemy.EnemyMovement;
        private HeroMovement HeroMovement => _enemy.Target.HeroMovement;

        private void LateUpdate()
        {
            CheckVision();
            TryInteract();
        }

        private void OnDrawGizmosSelected()
        {
            Handles.color = Color.white;

            Handles.DrawWireArc(Transform.position, Vector3.up, Vector3.forward, 360, _visionRange);

            Gizmos.color = Color.green;

            Gizmos.DrawLine(_rayPoint.position, Transform.position + Transform.forward * _rayDistance);

            Gizmos.color = Color.yellow;

            var direction = DirectionFromAngle(_visionAngle, Transform.eulerAngles.y);
            var negativeDirection = DirectionFromAngle(_visionAngle * -1, Transform.eulerAngles.y);

            Gizmos.DrawLine(Transform.position, Transform.position + direction * _visionRange);
            Gizmos.DrawLine(Transform.position, Transform.position + negativeDirection * _visionRange);

            if(_state == EnemyState.Chase)
            {
                Gizmos.color = Color.red;

                Gizmos.DrawLine(Transform.position, Target.CenterPoint.position);
            }
        }

        private void OnEnable()
        {
            OnStateChanged += (state, oldState) =>
            {
                StartCoroutine(TryPlaceEndPoint(state, oldState));

                if (state == EnemyState.Chase && oldState == EnemyState.Patrol)
                {
                    print($"State: {state}; OldState: {oldState}");

                    _onChaseSound.Play();
                }
            };

            HeroMovement.OnStepSound += TryHearStep;
        }

        private void OnDisable()
        {
            OnStateChanged -= (state, oldState) =>
            {
                StartCoroutine(TryPlaceEndPoint(state, oldState));
            };

            HeroMovement.OnStepSound += TryHearStep;
        }

        private void OnValidate()
        {
            _visionAngle = _fieldOfView / 2;

            _fieldOfView = Mathf.Clamp(_fieldOfView, 0f, Mathf.Infinity);
            _visionRange = Mathf.Clamp(_visionRange, 0f, Mathf.Infinity);

            _enemyMemory = Mathf.Clamp(_enemyMemory, 0f, Mathf.Infinity);

            _rayDistance = Mathf.Clamp(_rayDistance, 0f, Mathf.Infinity);

            if(_enemy == null)
            {
                _enemy = GetComponent<Enemy>();
            }
        }

        private IEnumerator TryPlaceEndPoint(EnemyState state, EnemyState oldState)
        {
            if (state == EnemyState.Patrol && oldState == EnemyState.Chase)
            {
                _state = EnemyState.Seek;

                OnStateChanged?.Invoke(EnemyState.Seek, oldState);

                EnemyMovement.SetMovingPoint(Target.UnderPoint.position);

                yield return new WaitForSeconds(_enemyMemory);

                EnemyMovement.SetMovingPoint(Target.UnderPoint.position, () => 
                { 
                    _state = EnemyState.Patrol; 

                    OnStateChanged?.Invoke(EnemyState.Patrol, EnemyState.Seek); 
                });
            }
        }

        private void CheckVision()
        {
            var direction = (Target.CenterPoint.position - Transform.position).normalized;
            var ray = new Ray(Transform.position, direction);

            var state = _state;

            if (Vector3.Angle(Transform.forward, direction) < _visionAngle)
            {
                if (ray.Raycast<Hero>(_visionRange)) 
                {
                    _state = EnemyState.Chase;

                    OnStateChanged?.Invoke(EnemyState.Chase, state);

                    return;
                }
            }

            if (_state == EnemyState.Seek) return;

            _state = EnemyState.Patrol;

            OnStateChanged?.Invoke(EnemyState.Patrol, state);
        }

        private void TryInteract()
        {
            var ray = new Ray(_rayPoint.position, Transform.forward);

            if(ray.Raycast(out Interactable interactableObject, _rayDistance))
            {
                interactableObject.Interact(_enemy);
            }
        }

        private void TryHearStep(float hearRange)
        {
            if(Vector3.Distance(_enemy.Transform.position, Target.UnderPoint.position) <= hearRange)
            {
                var oldState = _state;

                _state = EnemyState.Seek;

                OnStateChanged?.Invoke(EnemyState.Seek, oldState);

                EnemyMovement.SetMovingPoint(Target.UnderPoint.position, () => { _state = EnemyState.Patrol; });
            }
        }
        
        private Vector3 DirectionFromAngle(float angle, float YRotation = 0)
        {
            angle += YRotation;
            
            return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
        }
    }
}