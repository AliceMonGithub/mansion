using System.Collections;
using UnityEngine;

namespace Codebase.InventoryLogic
{
    [CreateAssetMenu(fileName = "Tool name", menuName = "Tool")]
    public class Tool : Item
    {
        [Header("Tool properties")]
        [SerializeField] private ToolType _type;

        public ToolType Type => _type;
    }

    public enum ToolType
    {
        Hammer
    }
}