using Codebase.HeroLogic;
using Codebase.InventoryLogic;
using UnityEngine;

namespace Codebase.MinigamesLogic.Chess
{
    public class ChessBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform[] _placingPoints;

        private int _placedCount;

        public void TryPlacePiece(object sender)
        {
            Hero hero = sender as Hero;
            Item handItem = hero.Inventory.HandItem;
            
            if(hero && handItem != null)
            {
                if(handItem.ItemType == ItemType.ChessPiece)
                {
                    Instantiate(handItem.ItemPrefab, _placingPoints[handItem.ItemIndex]);
                    
                    hero.Inventory.RemoveItem(hero.Inventory.HandItem);

                    _placedCount++;

                    if(_placedCount == _placingPoints.Length)
                    {
                        print("All placed");
                    }
                }
            }
        }
    }
}