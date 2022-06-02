using Codebase.HeroLogic;
using UltEvents;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Codebase.CrossfireLogic
{
    public class CrossfireBehavior : MonoBehaviour
    {
        [SerializeField] private UltEvent _onObjectEnterEvent;
        [SerializeField] private UltEvent _onObjectExitEvent;

        [SerializeField] private Image _crossfireImage;

        [SerializeField] private HeroRaycast _heroRaycast;

        private void OnEnable()
        {
            _heroRaycast.OnObjectEnter += _onObjectEnterEvent.Invoke;
            _heroRaycast.OnObjectExit += _onObjectExitEvent.Invoke;
        }

        private void OnDisable()
        {
            _heroRaycast.OnObjectEnter -= _onObjectEnterEvent.Invoke;
            _heroRaycast.OnObjectExit -= _onObjectExitEvent.Invoke;
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