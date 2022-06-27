using Codebase.HeroLogic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.PointerEventData;

namespace Codebase.InventoryLogic
{
    public class ItemSlotBehavior : MonoBehaviour
    {
        [SerializeField] private HeroInventory _inventory;
        [SerializeField] private ItemSlot _slot;

        private Item _item;

        private void OnEnable()
        {
            _slot.PointerClick += Click;
        }

        private void OnDisable()
        {
            _slot.PointerClick -= Click;
        }

        private void OnValidate()
        {
            if (_inventory == null)
            {
                _inventory = FindObjectOfType<HeroInventory>();
            }

            if (_slot == null)
            {
                _slot = GetComponent<ItemSlot>();
            }
        }

        public void Initialize(Item item)
        {
            _item = item;
        }

        private void Click(PointerEventData eventData)
        {
            if (eventData.button == InputButton.Left)
            {
                TakeInHand();
            }
            else if (eventData.button == InputButton.Right)
            {
                Drop();
            }
        }

        private void TakeInHand()
        {
            _inventory.TakeInHand(_item);
        }

        private void Drop()
        {
            _inventory.DropItem(_item);
        }
    }
}