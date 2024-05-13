using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // Get billboard camera
    Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // LateUpdate is called after update
    void LateUpdate()
    {
        // Change canvas rotation to main camera rotation
        transform.rotation = _camera.transform.rotation;
    }
}
