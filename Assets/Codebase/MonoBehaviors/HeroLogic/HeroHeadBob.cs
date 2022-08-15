using Codebase.PhysicLogic;
using UnityEngine;

namespace Codebase.HeroLogic
{
    public class HeroHeadBob : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private float _runSpeed;

        [Header("Components")]
        [SerializeField] private Hero _hero;

        public SinusoidMoving SinusoidMoving => _hero.SinusoidMoving;
        public HeroMovement HeroMovement => _hero.HeroMovement;

        private void Update()
        {
            float speed = _hero.HeroMovement.Running ? _runSpeed : 12;

            SinusoidMoving.ExtraSpeed = speed;
            SinusoidMoving.Velosity = _hero.HeroMovement.Velosity;
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