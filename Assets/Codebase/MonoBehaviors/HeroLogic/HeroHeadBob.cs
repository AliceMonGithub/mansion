using Codebase.PhysicLogic;
using UnityEngine;

namespace Codebase.HeroLogic
{
    public class HeroHeadBob : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private float _runMultiply;

        [Header("Components")]
        [SerializeField] private Hero _hero;

        public SinusoidMoving SinusoidMoving => _hero.SinusoidMoving;
        public HeroMovement HeroMovement => _hero.HeroMovement;

        private void Update()
        {
            float multiply = _hero.HeroMovement.Running ? _runMultiply : 1;

            print(HeroMovement.Velosity);
        }

        private void OnValidate()
        {
            if (_hero == null)
            {
                _hero = GetComponent<Hero>();
            }
        }
    }
}