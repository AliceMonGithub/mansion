using UltEvents;
using UnityEngine;

namespace Codebase.DoorLogic
{
    public class DoorBehavior : MonoBehaviour
    {
        [SerializeField] private UltEvent _onOpenEvent;
        [SerializeField] private UltEvent _onCloseEvent;

        [SerializeField] private AudioClip _doorOpendSound;
        [SerializeField] private AudioClip _doorClosedSound;

        [SerializeField] private bool _opened;
        [SerializeField] private bool _locked;

        public void Interact()
        {
            if (_locked) return;

            if(_opened)
            {
                Close();
            }
            else
            {
                Open();
            }

            _opened = !_opened;
        }

        private void Open()
        {
            _onOpenEvent.Invoke();
            GetComponent<AudioSource>().PlayOneShot(_doorOpendSound);
        }

        private void Close()
        {
            _onCloseEvent.Invoke();
            GetComponent<AudioSource>().PlayOneShot(_doorClosedSound);
        }
    }
}