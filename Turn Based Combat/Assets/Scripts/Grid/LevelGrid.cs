using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance { get; private set; }
    
    [SerializeField] private Transform gridPrefab;
    
    private GridSystem<GridObject> gridSystem;
    void Awake()
    {
        if (Instance!= null)
        {
            Debug.LogError("There`s more than one LevelGrid " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        gridSystem = new GridSystem<GridObject>(10, 10,2f,(GridSystem<GridObject> g, GridPosition gridPosition) => new GridObject(g,gridPosition));
        //gridSystem.CreateGridObjects(gridPrefab);
        
    }

    public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
    }

    public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnitList();
    }

    public void RemoveUnitAtGridPosition(GridPosition gridPosition,Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }

    public void UnitMovedGridPosition(Unit unit, GridPosition fromGridPosition,GridPosition toGridPosition)
    {
        RemoveUnitAtGridPosition(fromGridPosition,unit);
        AddUnitAtGridPosition(toGridPosition,unit);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
}
