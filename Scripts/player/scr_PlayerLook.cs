using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class scr_Player : MonoBehaviour
{
    #region Properties
    Camera _plaCamera;

    bool _plaInvertX;
    bool _plaInvertY;
    #endregion

    // Start is called before the first frame update
    void StartLook()
    {
        _plaCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void UpdateLook()
    {
        // Turn controller
    }
}
