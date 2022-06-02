using Codebase.Services.InputService;
using UnityEngine;
using Zenject;

namespace Codebase.HeroLogic
{
    [RequireComponent(typeof(CharacterController))]
    public class HeroMovement : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private float _speed;
        [SerializeField] private float _smooth;

        [Header("Components")]
        [SerializeField] private Transform _transform;
        [SerializeField] private CharacterController _characterController;

        private MovementInput _input;

        private Vector2 _axis;
        private Vector2 _axisVelosity;

        [Inject]
        private void Construct(MovementInput input)
        {
            _input = input;
        }

        private Vector3 MoveDirection => (_transform.forward * _axis.y + _transform.right * _axis.x);

        private void Update()
        {
            Move();
        }

        private void OnValidate()
        {
            _speed = Mathf.Clamp(_speed, 0, Mathf.Infinity);
            _smooth = Mathf.Clamp(_smooth, 0, Mathf.Infinity);

            if(_transform == null)
            {
                _transform = transform;
            }

            if(_characterController == null)
            {
                _characterController = GetComponent<CharacterController>();
            }
        }

        private void Move()
        {
            SmoothAxis();

            MoveHero();
        }

        private void MoveHero()
        {
            var moveVelosity = _speed * Time.deltaTime * MoveDirection;

            _characterController.Move(moveVelosity);
        }

        private void SmoothAxis()
        {
            _axis = Vector2.SmoothDamp(_axis, _input.Axis.normalized, ref _axisVelosity, _smooth);
        }
    }
}