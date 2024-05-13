using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton code from Chase Mitchell (https://sneakydaggergames.medium.com/creating-manager-classes-in-unity-a77cf7edcba5)

    #region Properties
    // Variables
    static GameManager _gameInstance;
    [SerializeField] Equation[] _gmEquations;   // Equations
    [SerializeField] Spawn[] _gameSpawns;       // Game Spawns

    // Properties
    public static GameManager Instance
    {
        get
        {
            // If there is no instance of a game manager
            if (_gameInstance == null)
            {
                // Create an instance of the game manager
                _gameInstance = new GameManager();
            }

            // Return game manager instance
            return _gameInstance;
        }
    }
    #endregion

    // Awake is called before Start
    void Awake()
    {
        // Set the game manager reference to this
        _gameInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Spawn entities
        SpawnAll();
    }

    // Activate all spawn points
    public void SpawnAll()
    {
        // Loop through every spawn point
        foreach(Spawn spawn in _gameSpawns)
        {
            // Spawn entity
            spawn.Activate();
        }
    }

    public Equation GetEquation()
    {
        return _gmEquations[Random.Range(0, _gmEquations.Length - 1)];
    }
}
