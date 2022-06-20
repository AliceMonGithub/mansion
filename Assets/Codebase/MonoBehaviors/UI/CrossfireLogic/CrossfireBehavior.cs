using Codebase.HeroLogic;
using UltEvents;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Codebase.CrossfireLogic
{
    public class CrossfireBehavior : MonoBehaviour
    {
        [SerializeField] private Color _pointerEnterColor = Color.black;
        [SerializeField] private Color _pointerExitColor = Color.black;

        [Space]

        [SerializeField] private Image _crossfireImage;

        [SerializeField] private HeroRaycast _heroRaycast;

        private void Update()
        {
            if(_heroRaycast.Object)
            {
                CrossfireColor(_pointerEnterColor);
            }
            else
            {
                CrossfireColor(_pointerExitColor);
            }
        }

        private void OnValidate()
        {
            if(_crossfireImage == null)
            {
                _crossfireImage = GetComponent<Image>();
            }

            if(_heroRaycast == null)
            {
                _heroRaycast = FindObjectOfType<HeroRaycast>();
            }
        }

        public void CrossfireColor(Color color)
        {
            _crossfireImage.color = color;
        }
    }
}