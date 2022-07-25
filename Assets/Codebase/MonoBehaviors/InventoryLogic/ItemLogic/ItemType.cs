using UnityEngine;

namespace Codebase.InventoryLogic
{
    public enum ItemType
    {
        None,
        ChessPiece
    }

    public class ItemTypeBehaviour : MonoBehaviour
    {
        [SerializeField] private ItemType _type;

        public ItemType ItemType => _type;
    }
}
