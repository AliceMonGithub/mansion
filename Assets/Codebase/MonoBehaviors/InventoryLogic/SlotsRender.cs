using Codebase.HeroLogic;
using System.Collections.Generic;
using UnityEngine;

namespace Codebase.InventoryLogic
{
    public class SlotsRender : MonoBehaviour
    {
        [SerializeField] private List<ItemSlot> _slots;
        [SerializeField] private HandItemSlot _handSlot;

        [Space]

        [SerializeField] private HeroInventory _inventory;

        private void OnEnable()
        {
            RenderItemsSlots(_inventory.Items);
            RenderHandSlot(_inventory.HandItem);

            _inventory.ItemsCountChanged += RenderItemsSlots;
            _inventory.OnHandItemChanged += RenderHandSlot;
        }

        private void OnDisable()
        {
            _inventory.ItemsCountChanged -= RenderItemsSlots;
            _inventory.OnHandItemChanged -= RenderHandSlot;
        }

        private void OnValidate()
        {
            if (_inventory == null)
            {
                _inventory = FindObjectOfType<HeroInventory>();
            }
        }

        private void RenderItemsSlots(List<Item> items)
        {
            var slotIndex = 0;

            Clear();

            foreach (var item in items)
            {
                _slots[slotIndex].Initialize(item);

                slotIndex++;
            }
        }

        private void RenderHandSlot(Item item)
        {
            _handSlot.Initialize(item);
        }

        private void Clear()
        {
            _slots.ForEach(slot => slot.Initialize(null));
        }
    }
}