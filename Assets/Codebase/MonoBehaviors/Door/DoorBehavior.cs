using Codebase.EnemyLogic;
using UltEvents;
using UnityEngine;

namespace Codebase.DoorLogic
{
    public class DoorBehavior : MonoBehaviour
    {
        [SerializeField] private UltEvent _onOpenEvent;
        [SerializeField] private UltEvent _onCloseEvent;
        [SerializeField] private UltEvent _onKickDoorEvent;

        [SerializeField] private bool _opened;
        [SerializeField] private bool _locked;

        public void Interact(object sender)
        {
            if (_locked) return;

            if(_opened)
            {
                if (sender is Enemy) return;

                Close();
            }
            else
            {
                var enemy = sender as Enemy;

                if(enemy != null)
                {
                    if(enemy.State == EnemyState.Patrol)
                    {
                        Open();
                    }
                    else if(enemy.State == EnemyState.Seek || enemy.State == EnemyState.Chase)
                    {
                        KickDoor();
                    }

                    _opened = !_opened;

                    return;
                }

                Open();
            }

            _opened = !_opened;
        }

        private void Open()
        {
            _onOpenEvent.Invoke();
        }

        private void Close()
        {
            _onCloseEvent.Invoke();
        }

        private void KickDoor()
        {
            _onKickDoorEvent.Invoke();
        }
    }
}