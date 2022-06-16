using Codebase.PhysicLogic;
using UnityEngine;

namespace Codebase.HeroLogic
{
    public class HeroHeadBob : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private SinusoidMoving _sinusoidMoving;
        [SerializeField] private HeroMovement _heroMovement;

        private void Update()
        {
            _sinusoidMoving.Enabled = _heroMovement.Moving;
        }

        private void OnValidate()
        {
            if (_heroMovement == null)
            {
                _heroMovement = GetComponent<HeroMovement>();
            }

            if (_sinusoidMoving == null)
            {
                _sinusoidMoving = GetComponentInChildren<SinusoidMoving>();
            }
        }
    }
}