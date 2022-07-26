using Codebase.HeroLogic;
using Codebase.InventoryLogic;
using UnityEngine;
using Zenject;

namespace Codebase.Factories
{
    public class HandItemFactory : IFactory<HandItem, Hero, HandItem>
    {
        public HandItem Create(HandItem prefab, Hero hero)
        {
            return Object.Instantiate(prefab, hero.Transform.position, Quaternion.identity);
        }
    }
}