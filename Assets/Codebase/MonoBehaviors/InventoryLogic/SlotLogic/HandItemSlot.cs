using Codebase.HeroLogic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Codebase.InventoryLogic
{
    public class HandItemSlot : MonoBehaviour, IPointerClickHandler
    {
        public event PointerHandler PointerClick;
        public delegate void PointerHandler(PointerEventData eventData);

        [SerializeField] private HandItemSlotView _view;
        [SerializeField] private HandItemSlotBehavior _behavior;

        [Space]

        [SerializeField] private HeroInventory _heroInventory;

        private void OnValidate()
        {
            if(_view == null)
            {
                _view = GetComponent<HandItemSlotView>();
            }

            if(_behavior == null)
            {
                _behavior = GetComponent<HandItemSlotBehavior>();
            }

            if(_heroInventory == null)
            {
                _heroInventory = FindObjectOfType<HeroInventory>();
            }
        }

        public void Initialize(Item item)
        {
            _view.Initialize(item);
            _behavior.Initialize(item);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            PointerClick?.Invoke(eventData);
        }
    }
}