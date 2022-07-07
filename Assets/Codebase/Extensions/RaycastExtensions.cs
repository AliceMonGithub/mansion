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

        public static bool Raycast<TComponent>(this Ray ray, out TComponent component, out RaycastHit hit, float distance = Mathf.Infinity) where TComponent : MonoBehaviour
        {
            component = null;

            if (Physics.Raycast(ray, out hit, distance))
            {
                component = hit.collider.GetComponent<TComponent>();
            }

            return component != null;
        }

        public static bool Raycast<TComponent>(this Ray ray, float distance = Mathf.Infinity) where TComponent : MonoBehaviour
        {
            if(Physics.Raycast(ray, out var hit, distance))
            {
                return hit.collider.GetComponent<TComponent>() != null;
            }

            return false;
        }
    }
}