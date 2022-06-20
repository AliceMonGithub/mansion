using UnityEngine;

namespace Codebase.InventoryLogic
{
    public class ItemModel : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;

        public GameObject GameObject => _gameObject;

        private void OnValidate()
        {
            if(_gameObject == null)
            {
                _gameObject = gameObject;
            }
        }
    }
}