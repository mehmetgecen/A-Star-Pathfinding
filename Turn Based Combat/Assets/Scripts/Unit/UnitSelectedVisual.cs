using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] private Unit unit;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedChanged;
        UpdateVisuals();
    }

    private void UnitActionSystem_OnSelectedChanged(object sender, EventArgs empty)
    {
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        if (UnitActionSystem.Instance.GetSelectedUnit() == unit)
        {
            _meshRenderer.enabled = true;
        }
        else
        {
            _meshRenderer.enabled = false;
        }
    }
}
