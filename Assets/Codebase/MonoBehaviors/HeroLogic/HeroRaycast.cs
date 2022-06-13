using Codebase.ExtensionPhysics;
using Codebase.Services.InteractService;
using System;
using UltEvents;
using UniRx;
using UnityEngine;

namespace Codebase.HeroLogic
{
    public class HeroRaycast : MonoBehaviour
    {
        public event OnObjectEnterHandler OnObjectEnter;
        public delegate void OnObjectEnterHandler();

        public event OnObjectExitHandler OnObjectExit;
        public delegate void OnObjectExitHandler();

        [SerializeField] private string _interactButton;

        [Space]

        [SerializeField] private float _distance;

        [Space]

        [SerializeField] private Transform _point;

        [Space]

        [SerializeField] private Hero _hero;

        private Interactable _object;
        private Interactable _recent;

        public bool Object => _object != null;

        private void Update()
        {
            _recent = _object;

            DrawRay();
            CheckEvent();

            if (Input.GetButtonDown(_interactButton) && _object != null)
            {
                _object.Interact(_hero);
            }
        }

        private void OnValidate()
        {
            if (_point == null)
            {
                _point = transform;
            }

            _distance = Mathf.Clamp(_distance, 0, Mathf.Infinity);
        }

        private void DrawRay()
        {
            var ray = new Ray(_point.position, _point.forward);

            ray.Raycast(out _object, _distance);
        }

        private void CheckEvent()
        {
            if (_recent != null && _object == null)
            {
                OnObjectExit?.Invoke();
            }
            else if (_recent == null && _object != null)
            {
                OnObjectEnter?.Invoke();
            }
        }
    }
}