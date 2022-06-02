using UnityEngine;

namespace Codebase.Services.InputService
{
    public abstract class MovementInput : IInputService
    {
        protected const string HorizontalAxis = "Horizontal";
        protected const string VerticalAxis = "Vertical";

        public abstract Vector2 Axis { get; }
    }
}