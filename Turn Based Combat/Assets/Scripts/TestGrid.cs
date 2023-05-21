using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrid : MonoBehaviour
{
    [SerializeField] private Transform gridPrefab;
    private GridSystem gridSystem;
    void Start()
    {
        gridSystem = new GridSystem(10, 10,2f);
        gridSystem.CreateGridObjects(gridPrefab);
        //Debug.Log(new GridPosition(2,5));
    }

    //TODO Update Method will be changed after MouseWorld Script is implemented.
    
    private void Update()
    {
        //Debug.Log(gridSystem.GetGridPosition(MouseWorld.GetPosition());
    }
}
