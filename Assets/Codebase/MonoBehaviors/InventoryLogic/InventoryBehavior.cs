using UltEvents;
using UnityEngine;

namespace Codebase.InventoryLogic
{
    public class InventoryBehavior : MonoBehaviour
    {
        [SerializeField] private UltEvent _openEvent;
        [SerializeField] private UltEvent _closeEvent;

        [SerializeField] private UltEvent _onCloseEvent;

        public void Open()
        {
            _openEvent.Invoke();
        }

        public void Close()
        {
            _closeEvent.Invoke();
        }

        public void OnClose()
        {
            _onCloseEvent.Invoke();
        }

        // Это временное решение. В будущем будет сервис

        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Resume()
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