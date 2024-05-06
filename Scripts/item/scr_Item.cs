using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Item : MonoBehaviour, IUsable
{
    #region Properties
    // Variables
    [Header("Item Settings")]
    [SerializeField] char _itemValue;

    [Header("Audio Clips")]
    [SerializeField] AudioClip _itemGrabSound;
    [SerializeField] AudioClip _itemErrorSound;

    Camera _itemCamera;
    AudioSource _itemAudioSource;
    Spawnpoint _itemSpawn;

    // Properties
    public Spawnpoint Spawn { get { return _itemSpawn; } set { _itemSpawn = value; } }
    public char Value { get { return _itemValue; } }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Get the main camera
        _itemCamera = Camera.main;

        // Get audio source
        _itemAudioSource = GetComponent<AudioSource>();
    }

    // Called after Update
    void LateUpdate()
    {
        // Change x,z rotation to main camera rotation
        transform.rotation = _itemCamera.transform.rotation;
    }

    public void OnUse(scr_Player user)
    {
        // If user has no items equipped
        if (user.Item == null)
        {
            // Disable collider
            GetComponent<CapsuleCollider>().enabled = false;

            // Set spawnpoint to empty
            _itemSpawn.Full = false;

            // Play sound
            _itemAudioSource.PlayOneShot(_itemGrabSound);

            // Add item to user inventory
            user.Item = this;

            // Parent item to player hands
            transform.SetParent(user.HandsTransform);

            // Move item to player hands
            transform.localPosition = Vector3.zero;
        }

        // If player has item equipped
        else
        {
            // Play sound
            _itemAudioSource.PlayOneShot(_itemErrorSound);
        }
    }
}
