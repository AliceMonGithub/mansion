using Codebase.Factories;
using Codebase.InventoryLogic;
using System.Collections.Generic;
using UnityEngine;

namespace Codebase.HeroLogic
{
    public class HeroInventory : MonoBehaviour
    {
        public event ItemHandler OnAddItem;
        public event ItemHandler OnDropItem;
        public event ItemHandler OnHandItemChanged;

        public delegate void ItemHandler(Item item);

        public event ItemsCountHandler ItemsCountChanged;
        public delegate void ItemsCountHandler(List<Item> items);

        [SerializeField] private string _openInventoryButton;

        [Space]

        [SerializeField] private List<Item> _items;

        [Space]

        [SerializeField] private Transform _modelMovingTarget;
        [SerializeField] private Transform _modelRotatingTarget;

        [Space]

        [SerializeField] private InventoryBehavior _inventory;
        [SerializeField] private Hero _hero;

        private ItemDropFactory _itemDropFactory = new ItemDropFactory();
        private HandItemFactory _handItemFactory = new HandItemFactory();

        private HandItem _itemModel;
        private Item _handItem;

        public List<Item> Items => _items;

        public Item HandItem => _handItem;
        public ItemType HandItemType => _handItem.ItemType;

        public Transform DropPoint => _hero.DropPoint;
        public Transform HandPoint => _hero.HandPoint;

        private void Awake()
        {

        }

        private void Update()
        {
            if (Input.GetButtonDown(_openInventoryButton))
            {
                _inventory.Open();
            }
        }

        private void OnValidate()
        {
            if (_inventory == null)
            {
                _inventory = FindObjectOfType<InventoryBehavior>();
            }

            if (_hero == null)
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

        public void RemoveItem(Item item)
        {
            if (item == _handItem)
            {
                Destroy(_itemModel.GameObject);

                _handItem = null;

                OnHandItemChanged?.Invoke(_handItem);
            }

            _items.Remove(item);

            OnDropItem?.Invoke(item);

            ItemsCountChanged?.Invoke(_items);
        }

        public void DropItem(Item item)
        {
            if (item == _handItem)
            {
                Destroy(_itemModel.GameObject);

                _handItem = null;

                OnHandItemChanged?.Invoke(_handItem);
            }

            _items.Remove(item);

            var drop = _itemDropFactory.Create(item.DropPrefab, DropPoint.position);

            drop.Initialize(item, this);

            OnDropItem?.Invoke(item);

            ItemsCountChanged?.Invoke(_items);
        }

        public void TakeInHand(Item item)
        {
            // _items.Remove(item);

            _itemModel = _handItemFactory.Create(item.ModelPrefab, _hero);

            _itemModel.Initialize(_modelMovingTarget, _modelRotatingTarget);

            _handItem = item;

            OnHandItemChanged?.Invoke(_handItem);

            ItemsCountChanged?.Invoke(_items);
        }

        public void PutInInventory(Item item)
        {
            // _items.Add(item);

            Destroy(_itemModel.GameObject);

            _handItem = null;

            OnHandItemChanged?.Invoke(_handItem);

            ItemsCountChanged?.Invoke(_items);
        }
    }
}
