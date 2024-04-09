using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class scr_Player : MonoBehaviour
{
    #region Properties
    [SerializeField] Transform _plaRecoilCamera;    // Player Recoil/Headbob Camera

    [Header("Head Bob Settings")]
    [SerializeField] AnimationCurve _plaHeadBob;    // Player Head Bob rotation curve
    [SerializeField] float _plaHeadBobMult = 1;     // Player Head Bob multiplier
    [SerializeField] float _plaWalkStepTime = 0.5f; // Player Walking Step Time
    [SerializeField] float _plaRunStepTime = 0.25f; // Player Running Step Time
    [SerializeField] float _plaStepDeadzone = 0.1f; // Player Step Speed Deadzone

    bool _plaStepping;                              // Player Stepping Boolean
    float _plaStepTime;                             // Player Step Time
    float _plaCurrentStepTime;                      // Player Current Step Time

    Quaternion _plaBobTargetRotation;
    #endregion

    // Start is called before the first frame update
    void StartHeadBob()
    {
        _plaCurrentStepTime = 0f;
    }

    // Update is called once per frame
    void UpdateHeadBob()
    {
        Debug.Log(_plaMoveState);
        Debug.Log("T - " + _plaCurrentStepTime);

        // Check player steps using speed
        StepStates();
    }

    void StepStates()
    {
        // If player is NOT still
        if (_plaMoveState != MoveState.STILL)
        {
            // Check if stepping
            CheckStep();
        }

        // If player is still
        else
        {
            // Magnitude method gained from Josh Sutphin (https://www.gamedeveloper.com/business/doing-thumbstick-dead-zones-right)
            // If player XZ movement is greater than step speed deadzone
            if (new Vector2(_plaMoveVector.x, _plaMoveVector.z).magnitude > _plaStepDeadzone)
            {
                // Check if stepping
                CheckStep();
            }
        }
    }

    void CheckStep()
    {
        // If player is not stepping
        if (!_plaStepping)
        {
            // Step
            StartCoroutine(Step());
        }
    }

    IEnumerator Step()
    {
        // Recoil technique modified from Gilbert (https://youtu.be/geieixA4Mqc?si=ObSRxS4_4-BW8XKl)

        // Set step to true
        _plaStepping = true;

        // Set current step time to 0
        _plaCurrentStepTime = 0;

        // Set step time
        float _stepTime = _plaStepTime;

        // While current step time is less than step time
        while (_plaCurrentStepTime < _stepTime)
        {
            // Add to step time
            _plaCurrentStepTime += Time.deltaTime;

            // Set rotation to bob rotation
            _plaRecoilCamera.localRotation = Quaternion.Euler(_plaHeadBob.Evaluate(_plaCurrentStepTime / _stepTime), 0, 0);

            // Return
            yield return null;
        }

        // Set step to false
        _plaStepping = false;

        // Return
        yield return null;
    }
}
