using System.Collections;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using Codebase.HeroLogic;

namespace Codebase.InventoryLogic
{
    public class ItemSlotView : MonoBehaviour
    {
        [SerializeField] private Image _image;

        [Space]

        [SerializeField] private HeroInventory _inventory;

        private void OnValidate()
        {
            if(_image == null)
            {
                _image = GetComponent<Image>();
            }
        }

        public void Initialize(Item item)
        {
            Render(item);
        }

        private void Render(Item item)
        {
            _image.enabled = false;
            
            if(item != null && item != _inventory.HandItem)
            {
                _image.sprite = item.Image;

                _image.enabled = true;
            }
        }
    }
}