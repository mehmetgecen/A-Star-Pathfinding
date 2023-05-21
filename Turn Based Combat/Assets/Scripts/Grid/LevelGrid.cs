using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] private Transform gridPrefab;
    
    private GridSystem gridSystem;
    void Awake()
    {
        gridSystem = new GridSystem(10, 10,1f);
        gridSystem.CreateGridObjects(gridPrefab);
        
    }

    /*public void SetUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        
    }

    public Unit GetUnitAtGridPositiıon(GridPosition gridPosition)
    {
        
    }

    public void ClearUnitAtGridPosition(GridPosition gridPosition)
    {
        
    }*/
}
