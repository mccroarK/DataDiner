using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class scr_Player : MonoBehaviour
{
    #region Properties
    [Header("Slide Settings")]
    [SerializeField] AudioSource _plaSlideSource;
    #endregion

    // Start is called before the first frame update
    void StartSlide()
    {
    }

    // Update is called once per frame
    void UpdateSlide()
    {
        // If player is moving on the ground/turning
        if (_plaController.velocity.magnitude > 0.001 && _plaMoveState != MoveState.FALLING)
        {
            // If sound is playing
            if (_plaSlideSource.isPlaying)
            {
                // Change slide volume using speed
                _plaSlideSource.volume = _plaController.velocity.magnitude / _plaDriveSpeed;
            }

            // If sound is not playing
            else
            {
                // Play the sound
                _plaSlideSource.Play();
            }
            
        }

        // If player is not moving/turning
        else
        {
            // If the sound is playing
            if (_plaSlideSource.isPlaying)
            {
                // Stop the sound
                _plaSlideSource.Stop();
            }
        }
    }
}
