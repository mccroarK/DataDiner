using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class scr_Player : MonoBehaviour
{
    #region Properties
    [Header("Step Settings")]
    [SerializeField] AnimationCurve _plaBobCurve;   // Player Bob Animation Curve
    [SerializeField] Vector3 _plaBobMult;           // Player Bob multiplier

    [SerializeField] float _plaBobTime = 1.0f;      // Player Bob Time
    [SerializeField] float _plaBobLerp = 1.0f;      // Player Bob Lerp Speed

    float _plaCurrentBobTime;                       // Player Current Bob Time

    Quaternion _plaBobTargetRotation;               // Player Bob Target Rotation
    #endregion

    // Start is called before the first frame update
    void StartHeadBob()
    {
        _plaCurrentBobTime = 0f;
    }

    // Update is called once per frame
    void UpdateHeadBob()
    {
        // Check player steps using speed
        CalculateBob();

        // Move camera
        MoveCamera();
    }

    void CalculateBob()
    {
        // Player is driving, and bob is not complete
        if (_plaMoveState == MoveState.DRIVING && _plaCurrentBobTime < _plaBobTime)
        {
            // Add to step time
            _plaCurrentBobTime += Time.deltaTime;

            // Set rotation to bob rotation
            _plaBobTargetRotation = Quaternion.Euler(
                _plaBobCurve.Evaluate(_plaCurrentBobTime / _plaBobTime) * _plaBobMult.x,
                _plaBobCurve.Evaluate(_plaCurrentBobTime / _plaBobTime) * _plaBobMult.y,
                _plaBobCurve.Evaluate(_plaCurrentBobTime / _plaBobTime) * _plaBobMult.z);
        }

        // If player is not driving or bob time is over 0
        else
        {
            // Reset bob time
            _plaCurrentBobTime = 0f;

            // Set target rotation to 0
            _plaBobTargetRotation = Quaternion.identity;
        }
    }

    void MoveCamera()
    {
        // Move camera rotation to target rotation
        _plaRecoilCamera.localRotation = Quaternion.Lerp(_plaRecoilCamera.localRotation, _plaBobTargetRotation, _plaBobLerp * Time.deltaTime);
    }
}
