using Codebase.PhysicLogic;
using UnityEngine;

namespace Codebase.HeroLogic
{
    public class HeroHeadBob : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Hero _hero;

        public SinusoidMoving SinusoidMoving => _hero.SinusoidMoving;
        public HeroMovement HeroMovement => _hero.HeroMovement;

        private void Update()
        {
            SinusoidMoving.ExtraStrength = HeroMovement.Velosity;
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