using UnityEngine;

namespace Codebase.PhysicLogic
{
    public class SinusoidMoving : MonoBehaviour
    {
        [Header("Properties")]
        [Min(0), SerializeField] private float _movingStrength;
        [Min(0), SerializeField] private float _movingSpeed;

        [Min(0), SerializeField] private float _movingSmooth;

        [Header("Components")]
        [SerializeField] private Transform _transform;

        private Vector3 _startPosition;
        private float _timer;

        public bool Enabled { get; set; }

        private void Start()
        {
            _startPosition = _transform.localPosition;
        }

        private void Update()
        {
            var newPosition = _startPosition;

            if (Enabled)
            {
                _timer += Time.deltaTime * _movingSpeed;

                newPosition.y += Mathf.Sin(_timer) * _movingStrength;

                _transform.localPosition = newPosition;
            }
            else
            {
                _timer = 0;

                _transform.localPosition = Vector3.Lerp(_transform.localPosition, _startPosition, _movingSmooth * Time.deltaTime);
            }
        }

        private void OnValidate()
        {
            _movingStrength = Mathf.Clamp(_movingStrength, 0, Mathf.Infinity);
            _movingSpeed = Mathf.Clamp(_movingSpeed, 0, Mathf.Infinity);
            _movingSmooth = Mathf.Clamp(_movingSmooth, 0, Mathf.Infinity);

            if (_transform == null)
            {
                _transform = GetComponent<Transform>();
            }
        }
    }
}