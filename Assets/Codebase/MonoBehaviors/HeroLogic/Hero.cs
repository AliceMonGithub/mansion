using UnityEngine;

namespace Codebase.HeroLogic
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private CharacterController _characterController;

        public Transform Transform => _transform;
        public CharacterController CharacterController => _characterController;

        private void OnValidate()
        {
            if(_transform == null)
            {
                _transform = transform;
            }

            if(_characterController == null)
            {
                _characterController = GetComponent<CharacterController>();
            }
        }
    }
}