using Codebase.PhysicLogic;
using UnityEngine;

namespace Codebase.InventoryLogic
{
    public class HandItem : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;

        [SerializeField] private SmoothMoving _smoothMoving;

        public GameObject GameObject => _gameObject;

        private void OnValidate()
        {
            if (_gameObject == null)
            {
                _gameObject = gameObject;
            }

            if (_smoothMoving == null)
            {
                _smoothMoving = GetComponent<SmoothMoving>();
            }
        }

        public void Initialize(Transform movingTarget, Transform rotatingTarget)
        {
            _smoothMoving.Initialize(movingTarget, rotatingTarget);
        }
    }
}