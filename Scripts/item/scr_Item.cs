using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IUsable
{
    #region Properties
    // Variables
    [Header("Item Settings")]
    [SerializeField] char _itemValue;               // Item value
    // Properties
    public char Value { get { return _itemValue; } }
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    public bool OnUse(scr_Player user)
    {
        // If inventory is not empty
        if (user.Inventory != null)
        {
            // Return fail
            return false;
        }

        // Disable collider
        GetComponent<Collider>().enabled = true;

        // Change parent and transform
        transform.SetParent(user.HandsTransform);
        transform.localPosition = Vector3.zero;

        // Add item to inventory
        user.Inventory = this;

        // Return success
        return true;
    }
}
