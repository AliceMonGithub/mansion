using Codebase.HeroLogic;
using Codebase.InventoryLogic;
using System.Collections;
using UnityEngine;

namespace Assets.Codebase.MonoBehaviors.CameraLogic
{
    public class InventoryTest : MonoBehaviour
    {
        

        [SerializeField] private HeroInventory _inventory;
        [SerializeField] private Item _item;

        private float _time;

        private void Update()
        {
            _time += Time.unscaledDeltaTime;

            if(_time >= 3)
            {
                AddItem();

                _time = 0;
            }
        }

        private void AddItem()
        {
            _inventory.AddItem(_item);

            Invoke(nameof(AddItem), 3f);
        }
    }
}