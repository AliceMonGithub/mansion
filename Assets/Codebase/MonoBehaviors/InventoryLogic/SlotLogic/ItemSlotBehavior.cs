using Codebase.HeroLogic;
using UnityEngine;

namespace Codebase.InventoryLogic
{
    public class ItemSlotBehavior : MonoBehaviour
    {
        [SerializeField] private HeroInventory _inventory;

        private Item _item;

        private void OnValidate()
        {
            if(_inventory == null)
            {
                _inventory = FindObjectOfType<HeroInventory>();
            }
        }

        public void Initialize(Item item)
        {
            _item = item;
        }

        public void Drop()
        {
            _inventory.DropItem(_item);
        }
    }
}