using UnityEngine;

namespace Codebase.PhysicLogic
{
    public class SinusoidMoving : MonoBehaviour
    {
        [Header("Properties")]
        [Min(0), SerializeField] private float _movingStrength;
        [Min(0), SerializeField] private float _movingSpeed;

        [Header("Components")]
        [SerializeField] private Transform _transform;

        private Vector3 _startPosition;
        private float _timer;

        public float ExtraSpeed { get => _movingSpeed; set => _movingSpeed = value; }
        public float Velosity { get; set; }

        private void Start()
        {
            _startPosition = _transform.localPosition;
        }

        private void Update()
        {
            var newPosition = _startPosition;

            _timer += Time.deltaTime * _movingSpeed;

            newPosition.y += Mathf.Sin(_timer) * _movingStrength * Velosity;

            _transform.localPosition = newPosition;
        }

        private void OnValidate()
        {
            _movingStrength = Mathf.Clamp(_movingStrength, 0, Mathf.Infinity);
            _movingSpeed = Mathf.Clamp(_movingSpeed, 0, Mathf.Infinity);

            if (_transform == null)
            {
                _transform = GetComponent<Transform>();
            }
        }
    }
}