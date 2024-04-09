using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class scr_Player : MonoBehaviour
{
    #region Properties
    bool _plaMenuOpen = false;
    #endregion

    // Start is called before the first frame update
    void StartMenu()
    {
        CloseMenu();
    }

    // Update is called once per frame
    void UpdateMenu()
    {
        //Debug.Log(_plaMenuOpen);
    }

    void OpenMenu()
    {
        // Open the menu
        _plaMenuOpen = true;

        // Unlock the cursor
        Cursor.lockState = CursorLockMode.Confined;

        // Set cursor to visible
        Cursor.visible = true;
    }

    void CloseMenu()
    {
        // Open the menu
        _plaMenuOpen = false;

        // Unlock the cursor
        Cursor.lockState = CursorLockMode.Locked;

        // Set cursor to visible
        Cursor.visible = false;
    }
}