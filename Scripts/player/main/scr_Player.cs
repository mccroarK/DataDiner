using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class scr_Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Main
        StartInput();
        StartStates();
        StartMove();
        StartLook();
        StartUse();

        // Extra
        StartSlide();
        StartCrash();
        StartHeadBob();
    }

    // Update is called once per frame
    void Update()
    {
        // Main
        UpdateInput();
        UpdateStates();
        UpdateMove();
        UpdateLook();
        UpdateUse();

        // Extra
        UpdateSlide();
        UpdateCrash();
        UpdateHeadBob();
    }
}