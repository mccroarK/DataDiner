using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class scr_Player : MonoBehaviour
{
    enum MoveState
    {
        STILL,                  // Player Standing Still
        WALKING,                // Player Walking
        RUNNING                 // Player Running
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
        // If player is not moving
        if (_plaMoveInput == Vector2.zero)
        {
            _plaMoveState = MoveState.STILL;
        }

        // If player is moving
        else
        {
            // If player is not holding Shift
            if (!_plaRunning)
            {
                _plaMoveState = MoveState.WALKING;
            }

            // If player is holding Shift
            else
            {
                _plaMoveState = MoveState.RUNNING;
            }
        }
    }

    void ActMoveState()
    {
        switch (_plaMoveState)
        {
            // Player is walking
            case MoveState.WALKING:
                _plaSpeed = _plaWalkSpeed;
                break;

            // Player is running
            case MoveState.RUNNING:
                _plaSpeed = _plaRunSpeed;
                break;

            // Player is still
            default:
                _plaSpeed = 0;
                break;
        }
    }
}
