using Codebase.PhysicLogic;
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

        [SerializeField] private HeroMovement _heroMovement;
        [SerializeField] private HeroInventory _heroInventory;
        [SerializeField] private HeroInteract _heroInteract;
        [SerializeField] private SinusoidMoving _sinusoidMoving;

        [Space]

        [SerializeField] private Transform _centerPoint;
        [SerializeField] private Transform _underPoint;
        [SerializeField] private Transform _dropPoint;
        [SerializeField] private Transform _handPoint;

        public GameObject GameObject => _gameObject;
        public Transform Transform => _transform;
        public CharacterController CharacterController => _characterController;

        public HeroMovement HeroMovement => _heroMovement;
        public HeroInventory Inventory => _heroInventory;
        public HeroInteract HeroInteract => _heroInteract;
        public SinusoidMoving SinusoidMoving => _sinusoidMoving;

        public Transform CenterPoint => _centerPoint;
        public Transform UnderPoint => _underPoint;
        public Transform DropPoint => _dropPoint;
        public Transform HandPoint => _handPoint;

        private void OnValidate()
        {
            if (_gameObject == null)
            {
                _gameObject = gameObject;
            }

            if (_transform == null)
            {
                _transform = transform;
            }

            if (_characterController == null)
            {
                _characterController = GetComponent<CharacterController>();
            }

            if(_heroMovement == null)
            {
                _heroMovement = GetComponent<HeroMovement>();
            }

            if(_heroInventory == null)
            {
                _heroInventory = GetComponent<HeroInventory>();
            }

            if(_sinusoidMoving == null)
            {
                _sinusoidMoving = GetComponentInChildren<SinusoidMoving>();
            }
        }

        public void Enable()
        {
            HeroMovement.enabled = true;
        }

        public void Disable()
        {
            HeroMovement.enabled = false;

            HeroMovement.Clear();
        }
    }
}