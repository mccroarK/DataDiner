using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class scr_Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartInput();
        StartStates();
        StartMove();
        StartLook();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
        UpdateStates();
        UpdateMove();
        UpdateLook();
    }
}
