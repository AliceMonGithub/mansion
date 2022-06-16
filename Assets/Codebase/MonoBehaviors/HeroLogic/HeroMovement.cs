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
        [SerializeField] private Hero _hero;

        private MovementInput _input;

        private Vector2 _axis;
        private Vector2 _axisVelosity;

        [Inject]
        private void Construct(MovementInput input)
        {
            _input = input;
        }

        public bool Moving => _input.Axis.sqrMagnitude != 0;

        private Vector3 MoveDirection => (Transform.forward * _axis.y + Transform.right * _axis.x);

        public Transform Transform => _hero.Transform;
        public CharacterController CharacterController => _hero.CharacterController;

        private void Update()
        {
            Move();
        }

        private void OnValidate()
        {
            _speed = Mathf.Clamp(_speed, 0, Mathf.Infinity);
            _smooth = Mathf.Clamp(_smooth, 0, Mathf.Infinity);

            if(_hero == null)
            {
                _hero = GetComponent<Hero>();
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

            print(MoveDirection);

            CharacterController.Move(moveVelosity);
        }

        private void SmoothAxis()
        {
            _axis = Vector2.SmoothDamp(_axis, _input.Axis.normalized, ref _axisVelosity, _smooth);
        }
    }
}