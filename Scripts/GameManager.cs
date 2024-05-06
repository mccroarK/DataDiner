using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Properties
    // Variables
    static GameManager instance;
    [SerializeField] Equation[] _gmEquations;   // Equations
    [SerializeField] Spawnpoint[] _spawnPoints; // Spawn Points

    // Properties
    public static GameManager Instance
    {
        get
        {
            // If no instance of game manager
            if (instance == null)
            {
                // Find this game manager
                instance = FindObjectOfType<GameManager>();
            }

            // Return game manager instance
            return instance;
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Spawn entities
        SpawnAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAll()
    {
        // Loop through every spawn point
        foreach(Spawnpoint spawnpoint in _spawnPoints)
        {
            // Spawn entity
            Spawn(spawnpoint);
        }
    }

    void Spawn(Spawnpoint spawnpoint)
    {
        // If spawn is not full
        if (!spawnpoint.Full)
        {
            // Spawn entity at spawn location
            GameObject _object = Instantiate(spawnpoint.Entity, spawnpoint.Position, Quaternion.identity);

            // If object is customer
            if (_object.TryGetComponent(out scr_Customer customer))
            {
                // Set customer spawn
                customer.Spawn = spawnpoint;

                // Set spawnpoint to full
                customer.Spawn.Full = true;

                // Set customer equation
                customer.Equation = _gmEquations[Random.Range(0, _gmEquations.Length - 1)];
            }

            // Else if object is item
            else if (_object.TryGetComponent(out scr_Item item))
            {
                // Set item spawn
                item.Spawn = spawnpoint;

                // Set spawnpoint to full
                item.Spawn.Full = true;
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
