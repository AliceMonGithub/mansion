using Lean.Transition;
using UltEvents;
using UnityEngine;

namespace Codebase.InventoryLogic
{
    public class InventoryBehavior : MonoBehaviour
    {
        [SerializeField] private GameObject _inventory;

        [Space]

        [SerializeField] private LeanManualAnimation _openAnimation;
        [SerializeField] private LeanManualAnimation _closeAnimation;

        private void OnValidate()
        {
            if(_inventory == null)
            {
                _inventory = gameObject;
            }
        }

        public void Open()
        {
            _inventory.SetActive(true);

            _openAnimation.BeginTransitions();

            ActiveCursor();
            PauseGame();
        }

        public void Close()
        {
            _closeAnimation.BeginTransitions();

            LockCursor();
            ResumeGame();

            _inventory.SetActive(false);
        }

        // Это временное решение. В будущем будет сервис

        private void PauseGame()
        {
            Time.timeScale = 0;
        }

        private void ResumeGame()
        {
            Time.timeScale = 1;
        }

        private void ActiveCursor()
        {
            Cursor.lockState = CursorLockMode.None;
        }

        private void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}