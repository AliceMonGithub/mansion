using UnityEngine;
using Zenject;

namespace Codebase.Zenject
{
    public class CursorInstaller : MonoInstaller
    {
        [SerializeField] private CursorLockMode _cursorMode;

        public override void InstallBindings()
        {
            Cursor.lockState = _cursorMode;
        }
    }
}
