using Codebase.HeroLogic;
using Codebase.Services.InputService;
using UnityEngine;
using Zenject;

namespace Codebase.CameraLogic
{
    public class HeroCamera : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private float _sensitivity;
        [SerializeField] private float _smooth;

        [Header("Components")]
        [SerializeField] private Transform _cameraTransform;

        [Space]

        [SerializeField] private Hero _hero;

        private ViewInput _input;

        private Vector2 _axis;
        private Vector2 _axisVelosity;

        private float _xRotation;

        [Inject]
        private void Construct(ViewInput input)
        {
            _input = input;
        }

        public Transform HeroTransform => _hero.Transform;

        private void Update()
        {
            Move();
        }

        private void OnValidate()
        {
            _sensitivity = Mathf.Clamp(_sensitivity, 0, Mathf.Infinity);
            _smooth = Mathf.Clamp(_smooth, 0, Mathf.Infinity);

            if(_cameraTransform == null)
            {
                _cameraTransform = GetComponentInChildren<Camera>().transform;
            }

            if(_hero == null)
            {
                _hero = GetComponent<Hero>();
            }
        }

        private void Move()
        {
            SmoothAxis();

            RotateCamera();
            RotateHero();

        }

        private void RotateCamera()
        {
            var delta = _axis.x * _sensitivity * Time.deltaTime;

            HeroTransform.Rotate(Vector3.up, delta);
        }

        private void RotateHero()
        {
            _xRotation -= _axis.y * _sensitivity * Time.deltaTime;

            _xRotation = Mathf.Clamp(_xRotation, -90, 90);

            _cameraTransform.localEulerAngles = Vector3.right * _xRotation;
        }

        private void SmoothAxis()
        {
            _axis = Vector2.SmoothDamp(_axis, _input.Axis.normalized, ref _axisVelosity, _smooth);
        }
    }
}