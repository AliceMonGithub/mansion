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

            _inventory.SetActive(false);
        }

        public void OnClose()
        {
            LockCursor();
            ResumeGame();
        }

        // Это временное решение. В будущем будет сервис

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
        }

        public void ActiveCursor()
        {
            Cursor.lockState = CursorLockMode.None;
        }

        public void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}