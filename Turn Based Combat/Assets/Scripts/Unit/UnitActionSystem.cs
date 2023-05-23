using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitActionSystem : MonoBehaviour
{
    [SerializeField] private Unit selectedUnit;
    [SerializeField] private LayerMask unitLayerMask;

    public event EventHandler OnSelectedUnitChanged;

    private void Update()
    {
        if(HandleUnitSelection()) return ;
        
        if (Input.GetMouseButtonDown(0))
        {
            selectedUnit.Move(MouseWorld.GetPosition());
        }
    }

    private bool HandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        if (Physics.Raycast(ray,out RaycastHit hit,float.MaxValue,unitLayerMask))
        {
            Unit unit = hit.transform.GetComponent<Unit>();
            
            if (unit!=null)
            {
                SetSelectedUnit(unit);
                return true;

            }
        }

        return false;

    }

    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        OnSelectedUnitChanged?.Invoke(this,EventArgs.Empty);
    }
}