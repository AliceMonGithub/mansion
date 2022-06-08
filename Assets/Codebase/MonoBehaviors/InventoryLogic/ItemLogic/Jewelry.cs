using UnityEngine;

namespace Codebase.InventoryLogic
{
    [CreateAssetMenu(fileName = "Jewelry name", menuName = "Jewelry")]
    public class Jewelry : Item
    {
        [Header("Jewelry properties")]
        [SerializeField] private int _cost;

        public int Cost => _cost;
    }
}