using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridObjectDebug : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textMeshPro;
    private object gridObject;

    public virtual void SetGridObject(object gridObject)
    {
        this.gridObject = gridObject;
    }

    protected virtual void Update()
    {
        _textMeshPro.text = gridObject.ToString();
    }
}
