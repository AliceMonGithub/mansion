using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSoundSteps : MonoBehaviour
{
    [SerializeField] private AudioSource _footstepsSound;
    [SerializeField] private AudioSource _sprintSound;

    private void PlayFootSound()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _footstepsSound.enabled = false;
                _sprintSound.enabled = true;
            }
            else
            {
                _footstepsSound.enabled = true;
                _sprintSound.enabled = false;
            }
        }
        else
        {
            _footstepsSound.enabled = false;
            _sprintSound.enabled = false;
        }
    }
    private void Update()
    {
        PlayFootSound();
    }
}
