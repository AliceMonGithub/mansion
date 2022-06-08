using System.Collections;
using UnityEngine;

namespace Codebase.InventoryLogic
{
    public class Item : ScriptableObject
    {
        [Header("Item properties")]
        [SerializeField] private string _name;
        [TextArea(), SerializeField] private string _description; 

        [Space]

        [SerializeField] private Sprite _image;

        [Space]

        [SerializeField] private ItemDrop _itemDrop;
        [SerializeField] private ItemModel _itemModel;
        
        public string Name => _name;
        public string Description => _description;

        public Sprite Image => _image;

        public ItemDrop ItemDrop => _itemDrop;
        public ItemModel ItemModel => _itemModel;
    }
}