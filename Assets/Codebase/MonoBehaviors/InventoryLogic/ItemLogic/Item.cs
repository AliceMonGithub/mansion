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

        [SerializeField] private ItemDrop _dropPrefab;
        [SerializeField] private HandItem _handItemPrefab;
        [SerializeField] private Transform _itemPrefab;

        public ItemType ItemType;
        public int ItemIndex;
        
        public string Name => _name;
        public string Description => _description;

        public Sprite Image => _image;

        public ItemDrop DropPrefab => _dropPrefab;
        public HandItem ModelPrefab => _handItemPrefab;
        public Transform ItemPrefab => _itemPrefab;
    }
}