using UniRx;
using UnityEngine;

namespace Codebase.InventoryLogic
{
    public class ItemSlot : MonoBehaviour
    {
        [SerializeField] private ItemSlotView _view;
        [SerializeField] private ItemSlotBehavior _behavior;

        private Item _item;

        private void OnValidate()
        {
            if(_view == null)
            {
                _view = GetComponent<ItemSlotView>();
            }

            if (_behavior == null)
            {
                _behavior = GetComponent<ItemSlotBehavior>();
            }
        }

        public void Initialize(Item item)
        {
            _item = item;

            _view.Initialize(item);
            _behavior.Initialize(item);
        }
    }
}