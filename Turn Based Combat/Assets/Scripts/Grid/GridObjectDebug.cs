using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridObjectDebug : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textMeshPro;
    private GridObject gridObject;
    private GridSystem gridSystem;
    
    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
    }

    private void Update()
    {
        _textMeshPro.text = gridObject.ToString();
    }
}
