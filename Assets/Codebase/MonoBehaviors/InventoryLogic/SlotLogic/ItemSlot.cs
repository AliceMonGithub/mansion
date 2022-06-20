﻿using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Codebase.InventoryLogic
{
    public class ItemSlot : MonoBehaviour, IPointerClickHandler
    {
        public event PointerHandler PointerClick;
        public delegate void PointerHandler(PointerEventData eventData);

        [SerializeField] private ItemSlotView _view;
        [SerializeField] private ItemSlotBehavior _behavior;

        private void OnValidate()
        {
            if(_view == null)
            {
                _view = GetComponent<ItemSlotView>();
            }

            if (_behavior == null)
            {
                _behavior = GetComponent<ItemSlotBehavior>();
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