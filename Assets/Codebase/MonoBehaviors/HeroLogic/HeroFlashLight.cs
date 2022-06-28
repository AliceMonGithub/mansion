using UnityEngine;

public class HeroFlashLight : MonoBehaviour
{
    [SerializeField] private GameObject _flashlight;

    [SerializeField] private AudioSource _audioSource;

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

        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
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

                _audioSource.Play();
            }
            else
            {
                _flashlight.SetActive(false);

                _flashlightEnabled = false;

                _audioSource.Play();
            }
        }
    }
}
