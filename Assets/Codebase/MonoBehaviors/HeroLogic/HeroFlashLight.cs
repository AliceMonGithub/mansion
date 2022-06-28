using UltEvents;
using UnityEngine;

public class HeroFlashLight : MonoBehaviour
{
    [SerializeField] private UltEvent _onInteract;

    [SerializeField] private GameObject _flashlight;

    [SerializeField] private string _flashlightButton;

    private bool _flashlightEnabled;

    private void Update()
    {
        TryInteract();
    }

    private void OnValidate()
    {
        _flashlightEnabled = _flashlight.activeSelf;

        if (_flashlight == null)
        {
            _flashlight = gameObject;
        }
    }

    private void TryInteract()
    {
        if (Input.GetButtonDown(_flashlightButton))
        {
            if (_flashlightEnabled == false)
            {
                _flashlight.SetActive(true);

                _flashlightEnabled = true;

                _onInteract.Invoke();
            }
            else
            {
                _flashlight.SetActive(false);

                _flashlightEnabled = false;

                _onInteract.Invoke();
            }
        }
    }
}
