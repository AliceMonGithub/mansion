using UnityEngine;

namespace Codebase.PhysicLogic
{
    public class SmoothMoving : MonoBehaviour
    {
        [SerializeField] private float _moveSmooth;
        [SerializeField] private float _rotateSmooth;

        [SerializeField] private Vector3 _rotationOffset;

        [Space]

        [SerializeField] private Transform _transform;

        private Transform _movingTarget;
        private Transform _rotatingTarget;

        private void LateUpdate()
        {
            var rotation = Quaternion.Euler(_rotatingTarget.eulerAngles + _rotationOffset);

            _transform.position = Vector3.Lerp(_transform.position, _movingTarget.position, _moveSmooth * Time.deltaTime);
            _transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, _rotateSmooth * Time.deltaTime);
        }

        private void OnValidate()
        {
            _moveSmooth = Mathf.Clamp(_moveSmooth, 0f, Mathf.Infinity);
            _rotateSmooth = Mathf.Clamp(_rotateSmooth, 0f, Mathf.Infinity);

            if(_transform == null)
            {
                _transform = transform;
            }
        }

        public void Initialize(Transform movingTarget, Transform rotatingTarget)
        {
            _movingTarget = movingTarget;
            _rotatingTarget = rotatingTarget;
        }
    }
}