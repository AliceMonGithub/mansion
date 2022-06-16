using Codebase.InventoryLogic;
using UnityEngine;
using Zenject;

namespace Codebase.Factories
{
    public class ItemDropFactory : IFactory<ItemDrop, Vector3, ItemDrop>
    {
        public ItemDrop Create(ItemDrop prefab, Vector3 position)
        {
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
