using Codebase.ExtensionPhysics;
using Codebase.Services.InteractService;
using UnityEngine;

namespace Codebase.HeroLogic
{
    public class HeroInteract : MonoBehaviour
    {
        public event InteractHandler InteractButtonDown;
        public delegate void InteractHandler();

        [SerializeField] private string _interactButton;

        [Space]

        [SerializeField] private float _distance;

        [Space]

        [SerializeField] private Transform _point;

        [Space]

        [SerializeField] private Hero _hero;

        private Interactable _object;

        public bool Object => _object != null;

        private void Update()
        {
            DrawRay();

            if (Input.GetButtonDown(_interactButton))
            {
                InteractButtonDown?.Invoke();

                if (_object != null)
                {
                    _object.Interact(_hero);
                }
            }
        }

        private void OnValidate()
        {
            if (_point == null)
            {
                _point = transform;
            }

            if (_hero == null)
            {
                _hero = GetComponent<Hero>();
            }

            _distance = Mathf.Clamp(_distance, 0, Mathf.Infinity);
        }

        private void DrawRay()
        {
            var ray = new Ray(_point.position, _point.forward);

            ray.Raycast(out _object, _distance);
        }
    }
}