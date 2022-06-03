using Codebase.InventoryLogic;
using UnityEngine;

namespace Codebase.HeroLogic
{
    public class HeroInventory : MonoBehaviour
    {
        [SerializeField] private string _openInventoryButton;

        [Space]

        [SerializeField] private InventoryBehavior _inventory;

        private void Update()
        {
            if(Input.GetButtonDown(_openInventoryButton))
            {
                _inventory.Open();
            }
        }
    }
}
