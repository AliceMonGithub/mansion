using Codebase.Services.InteractService;
using UnityEngine;

namespace Codebase.DoorLogic
{
    public class Door : Interactable
    {
        [SerializeField] private DoorBehavior _doorBehavior;

        private void OnValidate()
        {
            if(_doorBehavior == null)
            {
                _doorBehavior = GetComponent<DoorBehavior>();
            }
        }

        public override void Interact(object sender)
        {
            _doorBehavior.Interact();
        }
    }
}