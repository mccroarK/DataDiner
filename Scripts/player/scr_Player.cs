using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class scr_Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Main
        StartMenu();
        StartInput();
        StartStates();
        StartMove();
        StartLook();

        // Extra
        StartHeadBob();
    }

    // Update is called once per frame
    void Update()
    {
        // Main
        UpdateInput();
        UpdateStates();
        UpdateMenu();
        UpdateMove();
        UpdateLook();

        // Extra
        UpdateHeadBob();

        // Move character controller constantly
        // Move controller using Move Input, Current Player Speed, and Time
        _plaController.Move(_plaMoveVector * Time.deltaTime);   // Move outside script for menu?
    }
}