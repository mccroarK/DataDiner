using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Spawnpoint
{
    #region Properties
    // Variables
    [SerializeField] Transform _spawnPosition;
    [SerializeField] GameObject _spawnEntity;
    bool _spawnFull;

    // Properties
    public Vector3 Position { get { return _spawnPosition.position; } }
    public GameObject Entity { get { return _spawnEntity; } }
    public bool Full { get { return _spawnFull; } set { _spawnFull = value; } }
    #endregion
}
