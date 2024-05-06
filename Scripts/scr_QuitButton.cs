using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class scr_QuitButton : MonoBehaviour, IUsable
{
    #region Properties
    AudioSource _buttonAudioSource;
    #endregion

    void Start()
    {
        _buttonAudioSource = GetComponent<AudioSource>();
    }

    public void OnUse(scr_Player user)
    {
        // Play a sound
        _buttonAudioSource.Play();

        // Quit the game
        Application.Quit();
    }
}
