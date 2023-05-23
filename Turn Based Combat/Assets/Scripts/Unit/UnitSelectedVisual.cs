using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] private Unit unit;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void EnableVisual()
    {
        _meshRenderer.enabled = true;
    }

    public void DisableVisual()
    {
        _meshRenderer.enabled = false;
    }
}
