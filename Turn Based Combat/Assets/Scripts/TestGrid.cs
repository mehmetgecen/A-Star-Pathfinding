using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrid : MonoBehaviour
{
    private GridSystem gridSystem;
    void Start()
    {
        gridSystem = new GridSystem(10, 10,2f);
        
        //Debug.Log(new GridPosition(2,5));
    }

    private void Update()
    {
        //Debug.Log(gridSystem.GetGridPosition(MouseWorld.GetPosition());
    }
}
