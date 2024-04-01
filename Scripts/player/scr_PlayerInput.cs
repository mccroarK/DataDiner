using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(PlayerInput))]

public partial class scr_Player : MonoBehaviour
{
    #region Properties
    PlayerInput _plaInput;

    Vector2 _plaMoveInput;
    Vector2 _plaLookInput;

    bool _plaUsing;
    bool _plaRunning;
    #endregion

    // Start is called before the first frame update
    void StartInput()
    {
        // Get input component
        _plaInput = GetComponent<PlayerInput>();

        // Subscribe actions to methods
        _plaInput.actions["Move"].performed += ctx => GetMoveInput(ctx);
        _plaInput.actions["Look"].performed += ctx => GetLookInput(ctx);
        _plaInput.actions["Use"].performed += ctx => GetUseInput(ctx);

        _plaInput.actions["Run"].started += ctx => StartRun(ctx);
        _plaInput.actions["Run"].canceled += ctx => StopRun(ctx);
        //_plaMenuAction;
    }

    // Update is called once per frame
    void UpdateInput()
    {
        Debug.Log(_plaMoveInput);
    }

    void GetMoveInput(InputAction.CallbackContext ctx)
    {
        // Get WASD input
        _plaMoveInput = ctx.ReadValue<Vector2>();
    }

    void GetLookInput(InputAction.CallbackContext ctx)
    {
        // Get mouse delta
        _plaLookInput = ctx.ReadValue<Vector2>();
    }

    void GetUseInput(InputAction.CallbackContext ctx)
    {
        //
        Debug.Log("Using");
    }

    void StartRun(InputAction.CallbackContext ctx)
    {
        _plaRunning = true;
    }

    void StopRun(InputAction.CallbackContext ctx)
    {
        _plaRunning = false;
    }
}
