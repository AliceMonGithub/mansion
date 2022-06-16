using Codebase.HeroLogic;
using Codebase.Services.InteractService;
using UnityEngine;

namespace Codebase.InventoryLogic
{
    public class ItemDrop : Interactable
    {
        [SerializeField] private GameObject _gameObject;

        private HeroInventory _heroInventory;
        private Item _item;

        public override void Interact(object sender)
        {
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