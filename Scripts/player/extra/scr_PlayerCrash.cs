using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class scr_Player : MonoBehaviour
{
    #region Properties
    [Header("Crash Settings")]
    [SerializeField] AudioSource _plaCrashSource;
    [SerializeField] AudioClip[] _plaCrashSounds;
    [SerializeField] float _plaCrashThreshold = 5.0f;
    [SerializeField] float _plaCrashCooldown = 1.0f;
    [SerializeField] LayerMask _plaCrashLayer;

    bool _plaCrashing;
    #endregion

    // Start is called before the first frame update
    void StartCrash()
    {
        
    }

    // Update is called once per frame
    void UpdateCrash()
    {

    }

    void PlayCrashSound()
    {
        // If sound clip is not playing
        if (!_plaCrashSource.isPlaying)
        {
            // Choose a random clip
            _plaCrashSource.clip = _plaCrashSounds[Random.Range(0, _plaCrashSounds.Length - 1)];

            // Play a random crash sound
            _plaCrashSource.Play();
        }
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // If wall is hit
        if (hit.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            // Start coroutine of wall crash
            StartCoroutine(Crash());

            // If velocity is in threshold
            if (_plaController.velocity.magnitude >= _plaCrashThreshold)
            {
                // Play crash sound
                PlayCrashSound();
            }
        }
    }

    IEnumerator Crash()
    {
        // Set crash to true
        _plaCrashing = true;

        // Wait for 3 seconds
        yield return new WaitForSeconds(_plaCrashCooldown);

        // Set crash to false
        _plaCrashing = false;

        // Return null
        yield return null;
    }
}
