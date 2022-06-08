using UniRx;
using UnityEngine;

namespace Codebase.InventoryLogic
{
    public class ItemSlot : MonoBehaviour
    {
        [SerializeField] private Item _item;

        [Space]

        [SerializeField] private ItemSlotView _view;
        [SerializeField] private ItemSlotBehavior _behavior;

        public void Initialize(Item item)
        {
            _item = item;

            _view.Initialize(item);
            _behavior.Initialize(item);
        }
    }
}