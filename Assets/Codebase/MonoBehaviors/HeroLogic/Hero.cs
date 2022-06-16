using UnityEngine;

namespace Codebase.HeroLogic
{
    public class Hero : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Transform _transform;
        [SerializeField] private CharacterController _characterController;

        [Space]

        [SerializeField] private Transform _dropPoint;

        public GameObject GameObject => _gameObject;
        public Transform Transform => _transform;
        public CharacterController CharacterController => _characterController;

        public Transform DropPoint => _dropPoint;

        private void OnValidate()
        {
            if(_gameObject == null)
            {
                _gameObject = gameObject;
            }

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