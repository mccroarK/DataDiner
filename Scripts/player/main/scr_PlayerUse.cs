using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class scr_Player : MonoBehaviour
{
    #region Properties
    // Variables
    [Header("Use Settings")]
    [SerializeField] Transform _plaUseTransform;    // Use raycast origin
    [SerializeField] Transform _plaHandsTransform;  // Player hands
    [SerializeField] float _plaUseRange;            // Use raycast range

    scr_Item _plaItem;                              // Player item

    // Properties
    public Transform HandsTransform { get { return _plaHandsTransform; } }
    public scr_Item Item { get { return _plaItem; } set { _plaItem = value; } }
    #endregion

    // Start is called before the first frame update
    void StartUse()
    {
        
    }

    // Update is called once per frame
    void UpdateUse()
    {
        
    }

    void Use()
    {
        // Code by Rytech (https://youtu.be/K06lVKiY-sY?si=ewuFDsXU-k5aqbQ_)
        // Shoot a ray out
        Ray ray = new Ray(_plaUseTransform.position, _plaUseTransform.forward);

        // If ray hit something
        if (Physics.Raycast(ray, out RaycastHit hitInfo, _plaUseRange))
        {
            // If hit object is a usable object
            if (hitInfo.collider.gameObject.TryGetComponent(out IUsable usable))
            {
                // Use object
                usable.OnUse(this);
            }
        }
    }
}