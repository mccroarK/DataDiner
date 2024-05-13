using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    #region Properties
    [Header("Spawn Settings")]
    [SerializeField] GameObject _spawnObject;   // Spawn gameobject
    [SerializeField] float _spawnRadius = 0.5f; // Spawn object detection radius
    [SerializeField] LayerMask _spawnLayerMask; // Spawn object detection layermask

    bool _canSpawn = true;                      // Spawn boolean
    #endregion

    void Update()
    {
        if (Physics.CheckSphere(transform.position, _spawnRadius, _spawnLayerMask))
        {
            // Turn off spawn availability
            _canSpawn = false;
        }
        else
        {
            // Turn on spawn availability
            _canSpawn = true;
        }
    }

    public void Activate()
    {
        // Spawn the gameobject if spawning is available
        if (_canSpawn)
        {
            // Create an instance of the object at the spawn point transform
            Instantiate(_spawnObject, transform);
        }
    }
}
