using Codebase.HeroLogic;
using Codebase.InventoryLogic;
using UnityEngine;
using Zenject;

namespace Codebase.Factories
{
    public class HandItemFactory : IFactory<ItemModel, Hero, ItemModel>
    {
        public ItemModel Create(ItemModel prefab, Hero hero)
        {
            return Object.Instantiate(prefab, hero.Transform.position, Quaternion.identity);
        }
    }
}