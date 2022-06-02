using UnityEngine;

namespace Codebase.Services.InputService
{
    public class KeyboardMovementInput : MovementInput
    {
        public override Vector2 Axis => GetKeyboardAxis();

        private Vector2 GetKeyboardAxis()
        {
            return new Vector2(Input.GetAxisRaw(HorizontalAxis), Input.GetAxisRaw(VerticalAxis));
        }
    }
}