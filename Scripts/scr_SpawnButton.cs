using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SpawnButton : MonoBehaviour, IUsable
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

        // Spawn entities using game manager
        GameManager.Instance.SpawnAll();
    }
}
