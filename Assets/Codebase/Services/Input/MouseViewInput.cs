using UnityEngine;

namespace Codebase.Services.InputService
{
    public class MouseViewInput : ViewInput
    {
        public override Vector2 Axis => GetMouseDelta();
    
        private Vector2 GetMouseDelta()
        {
            return new Vector2(Input.GetAxisRaw(MouseXAxis), Input.GetAxisRaw(MouseYAxis));
        }
    }
}