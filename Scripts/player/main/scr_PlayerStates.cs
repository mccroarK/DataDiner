using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class scr_Player : MonoBehaviour
{
    enum MoveState
    {
        STILL,                  // Player Standing Still
        DRIVING,                // Player Driving
        CRASHING,               // Player Crashing
        FALLING                 // Player Falling
    }

    #region Properties
    MoveState _plaMoveState;    // Player move state
    #endregion

    // Start is called before the first frame update
    void StartStates()
    {
        
    }

    // Update is called once per frame
    void UpdateStates()
    {
        // Check move state using input
        CheckMoveState();

        // Act on move state
        ActMoveState();
    }

    void CheckMoveState()
    {
        // If player is grounded
        if (_plaController.isGrounded)
        {
            // If player is not moving
            if (_plaMoveInput == Vector2.zero)
            {
                _plaMoveState = MoveState.STILL;
            }

            // If player is moving
            else
            {
                // If player is not crashing
                if (!_plaCrashing)
                {
                    _plaMoveState = MoveState.DRIVING;
                }

                // If player is crashing
                else
                {
                    _plaMoveState = MoveState.CRASHING;
                }
            }
        }

        // If player is not grounded
        else
        {
            _plaMoveState= MoveState.FALLING;
        }
    }

    void ActMoveState()
    {
        switch (_plaMoveState)
        {
            // Player is still
            case MoveState.STILL:
                _plaSpeed = 0;
                _plaAccel = _plaDriveAccel;
                break;

            // Player is moving
            case MoveState.DRIVING:
                _plaSpeed = _plaDriveSpeed;
                _plaAccel = _plaDriveAccel;
                break;

            // Player is crashing
            case MoveState.CRASHING:
                _plaSpeed = _plaCrashSpeed;
                _plaAccel = _plaCrashAccel;
                break;

            // Player is falling
            default:
                _plaSpeed = 0;
                _plaAccel = _plaFallAccel;
                break;
        }
    }
}