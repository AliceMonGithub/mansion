using UltEvents;
using UnityEngine;

namespace Codebase.HidingObjectLogic
{
    public class HidingObjectBehavior : MonoBehaviour
    {
        [SerializeField] private UltEvent _insideEvent;
        [SerializeField] private UltEvent _outsideEvent;

        [SerializeField] private bool _inside;

        public void Interact()
        {
            if (_inside)
            {
                GetOutside();
                Debug.Log("Вылез");
            }
            else
            { 
                GetInside();
                Debug.Log("Залез");
            }

            _inside = !_inside;
        }

        

        private void GetInside()
        {
            _insideEvent.Invoke();
        }
        private void GetOutside()
        {
            _outsideEvent.Invoke();
        }
    }
}
 
