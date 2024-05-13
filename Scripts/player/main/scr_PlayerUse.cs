using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public partial class scr_Player : MonoBehaviour
{
    #region Properties
    // Variables
    [Header("Use Settings")]
    [SerializeField] Transform _plaUseTransform;    // Player use raycast origin
    [SerializeField] Transform _plaHandsTransform;  // Player hands
    [SerializeField] float _plaUseRange;            // Player use raycast range
    [SerializeField] LayerMask _plaUseLayer;        // Player use layermask
    [Header("Use Sounds")]
    [SerializeField] AudioClip _plaUseGood;         // Player good use sound
    [SerializeField] AudioClip _plaUseBad;          // Player bad use sound

    AudioSource _audioSource;                       // Audio source
    Item _inventory;                                     // Item

    // Properties
    public Item Inventory { get { return _inventory; } set { _inventory = value; } }
    public Transform HandsTransform { get { return _plaHandsTransform; } }
    #endregion

    // Start is called before the first frame update
    void StartUse()
    {
        // Get player audio source
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void UpdateUse()
    {
        
    }

    // Code by Rytech (https://youtu.be/K06lVKiY-sY?si=ewuFDsXU-k5aqbQ_)
    void Use()
    {
        // Shoot a ray out
        Ray ray = new Ray(_plaUseTransform.position, _plaUseTransform.forward);

        // If ray hit something
        if (Physics.Raycast(ray, out RaycastHit hitInfo, _plaUseRange, _plaUseLayer))
        {
            // If hit object is a usable object
            if (hitInfo.collider.gameObject.TryGetComponent(out IUsable usable))
            {
                // If hit object does not exist
                if (usable == null)
                {
                    // End function
                    return;
                }

                // Use usable object
                if (usable.OnUse(this))
                {
                    // Play success sound
                    _audioSource.PlayOneShot(_plaUseGood);
                }
                // Use fail
                else
                {
                    // Play fail sound
                    _audioSource.PlayOneShot(_plaUseBad);
                }
            }
        }
    }
}