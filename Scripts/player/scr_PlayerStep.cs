using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class scr_Player : MonoBehaviour
{
    #region Properties
    [Header("Step Settings")]
    [SerializeField] AnimationCurve _plaHeadBob;    // Player Head Bob rotation curve
    [SerializeField] Vector3 _plaHeadBobMult;       // Player Head Bob multiplier

    [SerializeField] float _plaWalkStepTime = 0.5f; // Player Walking Step Time
    [SerializeField] float _plaRunStepTime = 0.35f; // Player Running Step Time
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
            // If step time not reached
            if (_plaCurrentStepTime < _plaStepTime)
            {
                // Increment step timer
                _plaCurrentStepTime += Time.deltaTime;
            }

            // If step time is reached and player is not stepping
            else
            {
                // Trigger Step
                TriggerStep();
            }
        }

        // If player is still
        else
        {
            // Magnitude method gained from Josh Sutphin (https://www.gamedeveloper.com/business/doing-thumbstick-dead-zones-right)
            // If player XZ movement is greater than step speed deadzone
            if (new Vector2(_plaMoveVector.x, _plaMoveVector.z).magnitude > _plaStepDeadzone)
            {
                // Trigger Step
                TriggerStep();
            }
        }
    }

    void TriggerStep()
    {
        // Start step
        StartCoroutine(Step());
    }

    IEnumerator Step()
    {
        // If player is not stepping
        if (!_plaStepping)
        {
            // Reset step timer
            _plaCurrentStepTime = 0;

            // Set step to true
            _plaStepping = true;

            // Add step recoil
            StartCoroutine(Recoil(_plaHeadBob, _plaHeadBobMult, _plaStepTime));

            // Wait till end of step time
            yield return new WaitForSeconds(_plaStepTime);

            // Set step to false
            _plaStepping = false;
        }

        // Return
        yield return null;
    }
}
