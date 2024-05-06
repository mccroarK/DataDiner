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

        // Extra
        UpdateSlide();
        UpdateCrash();
        UpdateHeadBob();
    }
}