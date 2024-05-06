using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(AudioSource))]
public class scr_Customer : MonoBehaviour, IUsable
{
    #region Properties
    // Variables
    [Header("Audio Clips")]
    [SerializeField] AudioClip _custCorrectSound;
    [SerializeField] AudioClip _custErrorSound;
    [SerializeField] TMP_Text _custEquationText;
    [SerializeField] TMP_Text _custAnswerText;

    Spawnpoint _custSpawn;
    Camera _custCamera;
    Canvas _custCanvas;
    AudioSource _custAudioSource;
    Equation _custEquation;
    string _custPlayerAnswer = "";
    int _custIndex = 0;

    // Properties
    public Spawnpoint Spawn { get { return _custSpawn; } set { _custSpawn = value; } }
    public Equation Equation { get { return _custEquation; } set { _custEquation = value; } }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Get main camera
        _custCamera = Camera.main;

        // Get canvas
        _custCanvas = GetComponentInChildren<Canvas>();

        // Get audio source
        _custAudioSource = GetComponent<AudioSource>();

        // Change equation text
        _custEquationText.text = _custEquation.Question;
    }

    // Update is called once per frame
    void Update()
    {
        // Change x,z rotation to main camera rotation
        _custCanvas.transform.rotation = _custCamera.transform.rotation;
    }

    public void OnUse(scr_Player user)
    {
        // If user has item
        if (user.Item != null)
        {
            // Check answer
            CheckAnswer(user.Item);

            // Remove item
            Destroy(user.Item.gameObject);
        }

        // If use does not have item
        else
        {
            // Play error sound
            _custAudioSource.PlayOneShot(_custErrorSound);
        }
    }

    void CheckAnswer(scr_Item item)
    {
        // If solution[index] matches the item value
        if (item.Value == _custEquation.Answer[_custIndex])
        {
            // Add value to answer string
            _custPlayerAnswer += item.Value;

            // Change answer text value to answer
            _custAnswerText.text = _custPlayerAnswer;

            // If player answer string is equal to solution string
            if (_custPlayerAnswer == _custEquation.Answer)
            {
                // Set spawn full to false
                _custSpawn.Full = false;

                // Remove customer
                Destroy(gameObject);
            }

            // If player answer string not finished
            else
            {
                // Add to index
                _custIndex++;
            }
        }

        // If solution[index] does not match item value
        else
        {
            // Play error sound
            _custAudioSource.PlayOneShot(_custErrorSound);
        }
    }
}