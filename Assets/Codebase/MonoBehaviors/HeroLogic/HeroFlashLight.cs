using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFlashLight : MonoBehaviour
{
    [SerializeField] private GameObject _flashLight;

    [SerializeField] private AudioClip _flashLightSound;

    [SerializeField] private string _flashLightButton;

    [SerializeField] private bool _flashLightOn;


    private void Start()
    {
        _flashLight.SetActive(false);
    }

    private void FlashLightControl()
    {
        if (Input.GetButtonDown(_flashLightButton))
        {
            if (_flashLightOn == false)
            {
                _flashLight.SetActive(true);
                _flashLightOn = true;
                GetComponent<AudioSource>().PlayOneShot(_flashLightSound);
            }
            else
            {
                _flashLight.SetActive(false);
                _flashLightOn = false;
                GetComponent<AudioSource>().PlayOneShot(_flashLightSound);
            }
        }
    }

    void Update()
    {
        FlashLightControl();
    }
}
