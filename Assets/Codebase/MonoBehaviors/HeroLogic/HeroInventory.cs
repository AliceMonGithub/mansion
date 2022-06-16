using Codebase.Factories;
using Codebase.InventoryLogic;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Codebase.HeroLogic
{
    public class HeroInventory : MonoBehaviour
    {
        public event AddItemHandler OnAddItem;
        public delegate void AddItemHandler(Item item);

        public event DropItemHandler OnDropItem;
        public delegate void DropItemHandler(Item item);

        public event ItemsCountHandler ItemsCountChanged;
        public delegate void ItemsCountHandler(List<Item> items);

        [SerializeField] private string _openInventoryButton;

        [Space]

        [SerializeField] private List<Item> _items;

        [Space]

        [SerializeField] private InventoryBehavior _inventory;
        [SerializeField] private Hero _hero;

        private ItemDropFactory _factory = new ItemDropFactory();

        public List<Item> Items => _items;

        public Transform DropPoint => _hero.DropPoint;

        private void Update()
        {
            if(Input.GetButtonDown(_openInventoryButton))
            {
                _inventory.Open();
            }
        }

        private void OnValidate()
        {
            if(_inventory == null)
            {
                _inventory = FindObjectOfType<InventoryBehavior>();
            }

            if(_hero == null)
            {
                _hero = GetComponent<Hero>();
            }
        }

        public void AddItem(Item item)
        {
            _items.Add(item);

            OnAddItem?.Invoke(item);

            ItemsCountChanged?.Invoke(_items);
        }

        public void DropItem(Item item)
        {
            _items.Remove(item);

            var drop = _factory.Create(item.DropPrefab, DropPoint.position);

            drop.Initialize(item, this);

            OnDropItem?.Invoke(item);

            ItemsCountChanged?.Invoke(_items);
        }
    }
}
