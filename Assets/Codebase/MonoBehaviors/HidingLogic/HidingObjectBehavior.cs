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
            if (_inside)
            {
                // TODO
                //Debug.Log("Вылез");
                StartCoroutine(GetHiding(_hero.transform.position, _outsidePoint.position));
                _hero.CharacterController.enabled = true;
            }
            else
            {
                //Debug.Log("Залез");
                StartCoroutine(GetHiding(_hero.transform.position, _insidePoint.position));
                _hero.CharacterController.enabled = false;
            }

            _inside = !_inside;
        }

        IEnumerator GetHiding(Vector3 startPoint, Vector3 endPoint)
        {
            float time = 0f;

            while (time < 1)
            {
                time += Time.deltaTime / _time;
                //time = time + Time.deltaTime;
                //float percent = Mathf.Clamp01(time / duration);

                _hero.Transform.position = Vector3.Lerp(startPoint, endPoint, time);

                yield return null;
            }
        }
    }
}