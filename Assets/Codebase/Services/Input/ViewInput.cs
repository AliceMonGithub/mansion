using UnityEngine;

namespace Codebase.Services.InputService
{
    public abstract class ViewInput : IInputService
    {
        protected const string MouseXAxis = "Mouse X";
        protected const string MouseYAxis = "Mouse Y";

        public abstract Vector2 Axis { get; }
    }
}