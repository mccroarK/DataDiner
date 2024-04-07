using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public partial class scr_Player : MonoBehaviour
{
    #region Properties
    CharacterController _plaController;

    // Player state speeds
    [SerializeField] float _plaWalkSpeed = 2.5f;    // Walk speed
    [SerializeField] float _plaRunSpeed = 7.5f;     // Run speed
    [SerializeField] float _plaSpeedAccel = 1;      // Speed acceleration

    // Player speed variables
    float _plaSpeed;                                // Target speed

    // Player move vectors
    Vector3 _plaMoveVector;                         // Current move vector
    Vector3 _plaMoveVectorOld;                      // Stored move vector
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
        // Code Modified from Unity Documentation (https://docs.unity3d.com/ScriptReference/CharacterController.Move.html)
        // AND
        // Brackey's FPS Controller (https://youtu.be/_QajrabyTJc?si=NQ0-tVtGhx2XAab8)

        // Calculate move speed (DO NOT MODIFY MOVE INPUT)
        CalcMoveVector();

        // Move controller using Move Input, Current Player Speed, and Time
        _plaController.Move(_plaMoveVector * Time.deltaTime);   // Move outside script for menu?
    }

    void CalcMoveVector()
    {
        // Get move input relative to rotation
        Vector3 move = _plaMoveInput.x * transform.right + _plaMoveInput.y * transform.forward;

        // Accelerate old movement to target movement
        _plaMoveVector = Vector3.Lerp(_plaMoveVectorOld, new Vector3(move.x * _plaSpeed, 0, move.z * _plaSpeed), _plaSpeedAccel * Time.deltaTime);
        
        // Store old movement
        _plaMoveVectorOld = _plaMoveVector;
    }
}
