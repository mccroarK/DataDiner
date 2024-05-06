using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public partial class scr_Player : MonoBehaviour
{
    #region Properties
    CharacterController _plaController;

    // Player state speeds
    [Header("Move Speed Settings")]
    [SerializeField] float _plaDriveSpeed = 10.0f;  // Drive speed
    [SerializeField] float _plaCrashSpeed = 5.0f;   // Crash speed

    [Header("Move Acceleration Settings")]
    [SerializeField] float _plaDriveAccel = 2.5f;   // Drive speed acceleration
    [SerializeField] float _plaCrashAccel = 5.0f;   // Crash speed acceleration
    [SerializeField] float _plaFallAccel = 2.5f;    // Falling acceleration

    [Header("Gravity Settings")]
    [SerializeField] float _plaGroundGravity = 2.0f;// Ground gravity
    [SerializeField] float _plaFallGravity = 9.81f; // Falling gravity

    // Player speed variables
    float _plaSpeed;                                // Speed
    float _plaAccel;                                // Speed acceleration
    float _plaGravity;                              // Target gravity

    // Player move vectors
    Vector2 _moveInput;                             // Move Input Storage
    Vector3 _moveVector;                            // Move Vector
    Vector3 _moveVectorTarget;                      // Move Vector Target
    #endregion

    // Start is called before the first frame update
    void StartMove()
    {
        // Get player CharacterController
        _plaController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void UpdateMove()
    {
        // FPS Movement code modified from Unity Documentation (https://docs.unity3d.com/ScriptReference/CharacterController.Move.html)
        // AND
        // Brackey's FPS Controller (https://youtu.be/_QajrabyTJc?si=NQ0-tVtGhx2XAab8)

        // Check player state
        CheckState();

        // Calculate move vector target
        GetMoveTarget();

        // Calculate move
        GetMove();

        // Move controller using Move Input, Gravity, and Time
        _plaController.Move((_moveVector + (_plaGravity * transform.up)) * Time.deltaTime);
    }

    void CheckState()
    {
        // If player is grounded
        if (_plaMoveState != MoveState.FALLING)
        {
            // Change gravity
            _plaGravity = -_plaGroundGravity;

            // Update player move input
            _moveInput = _plaMoveInput;
        }

        else
        {
            // Add gravity
            _plaGravity += -(_plaFallGravity * Time.deltaTime);
        }
    }

    void GetMoveTarget()
    {
        // Get move vector target
        _moveVectorTarget = (_moveInput.x * transform.right + _moveInput.y * transform.forward) * _plaSpeed;
    }

    void GetMove()
    {
        // Move current move vector towards target
        _moveVector = Vector3.Lerp(_moveVector, _moveVectorTarget, _plaAccel * Time.deltaTime);
    }
}
