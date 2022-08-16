using Codebase.CameraLogic;
using Codebase.Services.InputService;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Codebase.HeroLogic
{
    [RequireComponent(typeof(CharacterController))]
    public class HeroMovement : MonoBehaviour
    {
        private const string RunBind = "Run";

        public event SoundHandler OnStepSound;
        public delegate void SoundHandler(float hearRange);

        [Header("Properties")]
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _runSpeed;
        [SerializeField] private float _smooth;

        [Space]

        [SerializeField] private float _fallSpeed;

        [Space]

        [SerializeField] private int _walkFOV;
        [SerializeField] private int _runFOV;

        [Header("Sounds")]
        [SerializeField] private AudioClip[] _stepsSound;
        [SerializeField] private AudioSource _audioSource;

        [Space]

        [SerializeField] private float _stepsFrequency;

        [Space]

        [SerializeField] private float _stepsVolumeRange;

        [Space]

        [SerializeField] private float _enableStrength;

        [Header("Components")]
        [SerializeField] private Hero _hero;

        [Space]

        [SerializeField] private DynamicFOV _dynamicFOV;

        private MovementInput _input;

        private Vector2 _axis;
        private Vector2 _axisVelosity;

        private float _stepTime;
        private float _gravity;

        [Inject]
        private void Construct(MovementInput input)
        {
            _input = input;
        }

        public float Velosity => (MoveDirection * _walkSpeed).magnitude / _walkSpeed;

        public bool Running => Input.GetButton(RunBind);

        private Vector3 MoveDirection => (Transform.forward * _axis.y + Transform.right * _axis.x);
        private AudioClip StepSound => _stepsSound[Random.Range(0, _stepsSound.Length)];

        private Transform Transform => _hero.Transform;
        private Transform UnderPoint => _hero.UnderPoint;
        private CharacterController CharacterController => _hero.CharacterController;

        private void Update()
        {
            Gravity();
            Move();

            TryPlayStepSound();
            SetFOV();
        }

        private void OnDrawGizmosSelected()
        {
            if (UnderPoint == null) return;

            Handles.color = Color.white;

            Handles.DrawWireArc(UnderPoint.position, Vector3.up, Vector3.forward, 360, _stepsVolumeRange);
        }

        private void OnValidate()
        {
            _walkSpeed = Mathf.Clamp(_walkSpeed, 0, Mathf.Infinity);
            _smooth = Mathf.Clamp(_smooth, 0, Mathf.Infinity);

            if (_hero == null)
            {
                _hero = GetComponent<Hero>();
            }
        }

        public void Clear()
        {
            _axis = Vector2.zero;
            _axisVelosity = Vector2.zero;
        }

        private void TryPlayStepSound()
        {
            if (Velosity >= _enableStrength)
            {
                _stepTime += Time.deltaTime;

                if (_stepTime >= _stepsFrequency)
                {
                    _audioSource.pitch = Random.Range(0.87f, 1.13f);

                    _audioSource.PlayOneShot(StepSound);

                    OnStepSound?.Invoke(_stepsVolumeRange);

                    _stepTime = 0f;
                }
            }
        }

        private void Move()
        {
            float speed = Input.GetButton(RunBind) ? _runSpeed : _walkSpeed;

            SmoothAxis();

            MoveHero(speed);
        }

        private void SetFOV()
        {
            _dynamicFOV.FOV = Running ? _runFOV : _walkFOV;
        }

        private void Gravity()
        {
            _gravity += _fallSpeed * Time.deltaTime;

            if(CharacterController.isGrounded)
            {
                _gravity = 0;
            }
        }

        private void MoveHero(float speed)
        {
            Vector3 moveVelosity = speed * Time.deltaTime * MoveDirection + Vector3.down * _gravity;

            CharacterController.Move(moveVelosity);
        }

        private void SmoothAxis()
        {
            _axis = Vector2.SmoothDamp(_axis, _input.Axis.normalized, ref _axisVelosity, _smooth);
        }
    }
}