using UnityEngine;

namespace Codebase.Services.InteractService
{
    public abstract class Interactable : MonoBehaviour, IInteractable
    {
        public abstract void Interact(object sender);
    }
}