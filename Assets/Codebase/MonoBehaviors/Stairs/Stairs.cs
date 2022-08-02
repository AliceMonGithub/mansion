using Codebase.HeroLogic;
using Codebase.Services.InputService;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Codebase.StairsLogic
{
    public class Stairs : MonoBehaviour
    {
        [SerializeField] private float _movingSpeed;
        [SerializeField] private float _movingToSaveTime;

        [Space]

        [SerializeField] private Transform _upperSavePoint;
        [SerializeField] private Transform _underSavePoint;

        [Space]

        [SerializeField] private Transform _upperPoint;
        [SerializeField] private Transform _underPoint;

        [Space]

        [SerializeField] private Mesh _heroMesh;

        private Hero _hero;
        private bool _movingToSave;
        private bool _movingUp;

        private bool _onStairs;

        private void Update()
        {
            if (_hero != null && _movingToSave == false)
            {
                MoveHero();
            }
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (_onStairs == false && collider.TryGetComponent(out Hero hero))
            {
                float distanceToUpper = Vector3.Distance(hero.Transform.position, _upperPoint.position);
                float distanceToUnder = Vector3.Distance(hero.Transform.position, _underPoint.position);

                if(distanceToUpper > distanceToUnder)
                {
                    _movingUp = true;
                }
                else
                {
                    _movingUp = false;
                }

                hero.Disable();

                _hero = hero;
                _onStairs = true;
            }
        }

        private void OnDrawGizmos()
        {
            if (_heroMesh == null) return;

            if(_upperSavePoint != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawMesh(_heroMesh, _upperSavePoint.position);
            }

            if (_underSavePoint != null)
            {
                Gizmos.DrawMesh(_heroMesh, _underSavePoint.position);
            }

            if (_upperPoint != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawMesh(_heroMesh, _upperPoint.position);
            }

            if (_underPoint != null)
            {
                Gizmos.DrawMesh(_heroMesh, _underPoint.position);
            }
        }

        private void MoveHero()
        {
            float axis = _movingUp ? 1 : -1;

            _hero.Transform.Translate(axis * _movingSpeed * Time.deltaTime * Vector3.up);

            if(_movingUp)
            {
                if (Vector3.Distance(_hero.CenterPoint.position, _upperPoint.position) <= 1.7f)
                {
                    StartCoroutine(MoveToSafeZone());
                }
            }
            else
            {
                if (Vector3.Distance(_hero.CenterPoint.position, _underPoint.position) <= 1.7f)
                {
                    StartCoroutine(MoveToSafeZone());
                }
            }
        }

        private IEnumerator MoveToSafeZone()
        {
            Vector3 startPosition = _hero.Transform.position;
            Vector3 endPosition = _movingUp ? _upperSavePoint.position : _underSavePoint.position;

            float time = 0f;

            _movingToSave = true;

            while(time < 1f)
            {
                time += Time.deltaTime / _movingToSaveTime;

                _hero.Transform.position = Vector3.Lerp(startPosition, endPosition, time);

                yield return null;
            }

            _hero.Enable();

            _hero = null;

            _movingToSave = false;
            _onStairs = false;
        }
    }
}