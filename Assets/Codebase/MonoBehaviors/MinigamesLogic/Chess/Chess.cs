using Codebase.Services.InteractService;
using UnityEngine;

namespace Codebase.MinigamesLogic.Chess
{
    public class Chess : Interactable
    {
        [SerializeField] private ChessBehaviour _chessBehaviour;

        public override void Interact(object sender)
        {
            _chessBehaviour.TryPlacePiece(sender);
        }
    }
}