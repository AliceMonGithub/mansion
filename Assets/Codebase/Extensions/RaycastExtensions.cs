using UnityEngine;

namespace Codebase.ExtensionPhysics
{
    public static class RaycastExtensions
    {
        public static bool Raycast<TComponent>(this Ray ray, out TComponent component, float distance = Mathf.Infinity) where TComponent : MonoBehaviour
        {
            component = null;

            if (Physics.Raycast(ray, out var hit, distance))
            {
                component = hit.collider.GetComponent<TComponent>();
            }

            return component != null;
        }
    }
}