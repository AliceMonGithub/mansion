using Codebase.InventoryLogic;
using UnityEngine;
using Zenject;

namespace Codebase.Factories
{
    public class HandItemFactory : IFactory<ItemModel, Transform, ItemModel>
    {
        public ItemModel Create(ItemModel prefab, Transform hand)
        {
            return Object.Instantiate(prefab, hand);
        }
    }
}