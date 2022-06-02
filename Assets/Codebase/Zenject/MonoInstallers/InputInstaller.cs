using Codebase.Services.InputService;
using Zenject;

namespace Codebase.Zenject
{
    public class InputInstaller : MonoInstaller
    {
        private readonly MovementInput _movementInput = new KeyboardMovementInput();
        private readonly ViewInput _viewInput = new MouseViewInput();

        public override void InstallBindings()
        {
            Container.Bind<MovementInput>().FromInstance(_movementInput);
            Container.Bind<ViewInput>().FromInstance(_viewInput);
        }
    }
}