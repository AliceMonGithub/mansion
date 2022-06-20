using Codebase.HeroLogic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.PointerEventData;

namespace Codebase.InventoryLogic
{
    public class HandItemSlotBehavior : MonoBehaviour
    {
        [SerializeField] private HeroInventory _inventory;
        [SerializeField] private HandItemSlot _slot;

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
                _slot = GetComponent<HandItemSlot>();
            }
        }

        public void Initialize(Item item)
        {
            _item = item;
        }

        private void Click(PointerEventData eventData)
        {
            if (_item == null) return;

            if (eventData.button == InputButton.Left)
            {
                print("Left button");

                PutInInventory();
            }
            //Работает с багом. Временно не работает.
            //else if (eventData.button == InputButton.Right)
            //{
            //    print("Right button");

            //    Drop();
            //}
        }

        private void PutInInventory()
        {
            _inventory.PutInInventory(_item);
        }

        private void Drop()
        {
            _inventory.DropItem(_item);
        }
    }
}