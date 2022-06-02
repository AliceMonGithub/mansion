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
        [SerializeField] private Transform _hero;
        [SerializeField] private Transform _camera;

        private ViewInput _input;

        private Vector2 _axis;
        private Vector2 _axisVelosity;

        private float _xRotation;

        [Inject]
        private void Construct(ViewInput input)
        {
            _input = input;
        }

        private void Update()
        {
            Move();
        }

        private void OnValidate()
        {
            _sensitivity = Mathf.Clamp(_sensitivity, 0, Mathf.Infinity);
            _smooth = Mathf.Clamp(_smooth, 0, Mathf.Infinity);

            if(_hero == null)
            {
                _hero = transform;
            }

            if(_camera == null)
            {
                _camera = GetComponentInChildren<Camera>().transform;
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

            _hero.Rotate(Vector3.up, delta);
        }

        private void RotateHero()
        {
            _xRotation -= _axis.y * _sensitivity * Time.deltaTime;

            _xRotation = Mathf.Clamp(_xRotation, -90, 90);

            _camera.localEulerAngles = Vector3.right * _xRotation;
        }

        private void SmoothAxis()
        {
            _axis = Vector2.SmoothDamp(_axis, _input.Axis.normalized, ref _axisVelosity, _smooth);
        }
    }
}