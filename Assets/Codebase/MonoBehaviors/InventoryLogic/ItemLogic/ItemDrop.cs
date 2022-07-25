using Codebase.HeroLogic;
using Codebase.Services.InteractService;
using UnityEngine;

namespace Codebase.InventoryLogic
{
    public class ItemDrop : Interactable
    {
        [SerializeField] private Item _item;

        [Space]

        [SerializeField] private ItemType _itemType;
        [SerializeField] private int _index;

        [Space]

        [SerializeField] private HeroInventory _heroInventory;

        [Space]

        [SerializeField] private GameObject _gameObject;

        private void OnValidate()
        {
            if(_gameObject == null)
            {
                _gameObject = gameObject;
            }

            if(_heroInventory == null)
            {
                _heroInventory = FindObjectOfType<HeroInventory>();
            }
        }

        public override void Interact(object sender)
        {
            _item.ItemType = _itemType;
            _item.ItemIndex = _index;

            _heroInventory.AddItem(_item);

            Destroy(_gameObject);
        }

        public void Initialize(Item item, HeroInventory heroInventory)
        {
            _heroInventory = heroInventory;
            _item = item;
        }
    }
}