using Codebase.HeroLogic;
using System.Collections;
using UnityEngine;

namespace Codebase.HidingObjectLogic
{
    public class HidingObjectBehavior : MonoBehaviour
    {
        [SerializeField] private Transform _insidePoint;
        [SerializeField] private Transform _outsidePoint;

        [SerializeField] private Hero _hero;

        [SerializeField] private float _time;

        [SerializeField] private bool _inside;

        private bool _moving;

        private void OnDestroy()
        {
            _hero.HeroInteract.InteractButtonDown -= Interact;
        }

        private void OnValidate()
        {
            _time = Mathf.Clamp(_time, 0f, Mathf.Infinity);

            if(_hero == null)
            {
                _hero = FindObjectOfType<Hero>();
            }
        }

        public void Interact()
        {
            if (_moving) return;

            if (_inside)
            {
                StartCoroutine(GetOut());
            }
            else
            {
                StartCoroutine(Hide());
            }

            _inside = !_inside;
        }

        private IEnumerator Hide()
        {
            var startPosition = _hero.Transform.position;
            var time = 0f;

            _moving = true;

            _hero.Disable();

            while (time < 1)
            {
                time += Time.deltaTime / _time;

                _hero.Transform.position = Vector3.Lerp(startPosition, _insidePoint.position, time);

                yield return null;
            }

            _hero.HeroInteract.InteractButtonDown += Interact;

            _moving = false;
        }

        private IEnumerator GetOut()
        {
            var startPosition = _hero.Transform.position;
            var time = 0f;

            _moving = true;

            _hero.HeroInteract.InteractButtonDown -= Interact;

            while (time < 1)
            {
                time += Time.deltaTime / _time;

                _hero.Transform.position = Vector3.Lerp(startPosition, _outsidePoint.position, time);

                yield return null;
            }

            _hero.Enable();

            _moving = false;
        }
    }
}