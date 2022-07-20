using UnityEngine;

namespace Codebase.EnemyLogic
{
    public class EnemyAnimator : MonoBehaviour
    {
        private readonly int SpeedHash = Animator.StringToHash("Speed");

        [SerializeField] private Animator _animator;

        [Space]

        [SerializeField] private Enemy _enemy;

        private void Update()
        {
            _animator.SetFloat(SpeedHash, _enemy.Velosity);
        }
    }
}