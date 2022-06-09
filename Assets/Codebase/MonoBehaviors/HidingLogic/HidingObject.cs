using Codebase.Services.InteractService;
using UnityEngine;

namespace Codebase.HidingObjectLogic
{
    public class HidingObject : Interactable
    {
        [SerializeField] private HidingObjectBehavior _hideBehavior;

        private void OnValidate()
        {
            if (_hideBehavior == null)
            {
                _hideBehavior = GetComponent<HidingObjectBehavior>();
            }
        }

        public override void Interact(object sender)
        {
            _hideBehavior.Interact();
        }
    }
}