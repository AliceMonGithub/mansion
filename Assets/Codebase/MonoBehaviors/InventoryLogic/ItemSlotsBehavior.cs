using Codebase.HeroLogic;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Codebase.InventoryLogic
{
    public class ItemSlotsBehavior : MonoBehaviour
    {
        [SerializeField] private List<ItemSlot> _slots;

        [Space]

        [SerializeField] private HeroInventory _inventory;

        private void OnEnable()
        {
            Render(_inventory.Items);

            _inventory.ItemsCountChanged += Render;
        }

        private void OnDisable()
        {
            _inventory.ItemsCountChanged -= Render;
        }

        private void OnValidate()
        {
            if(_inventory == null)
            {
                _inventory = FindObjectOfType<HeroInventory>();
            }
        }

        private void Render(List<Item> items)
        {
            var slotIndex = 0;

            Clear();

            foreach (var item in items)
            {
                _slots[slotIndex].Initialize(item);

                slotIndex++;
            }
        }

        private void Clear()
        {
            _slots.ForEach(slot => slot.Initialize(null)); // скорее всего временное решение
        }
    }
}