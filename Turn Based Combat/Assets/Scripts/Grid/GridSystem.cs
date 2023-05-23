using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem<TGridObject>
{
    private int width;
    private int height;
    private float cellSize;
    private TGridObject[,] gridObjects;
    
    public GridSystem(int width,int height,float cellSize,Func<GridSystem<TGridObject>,GridPosition,TGridObject>createGridObject)
    {
        this.height = height;
        this.width = width;
        this.cellSize = cellSize;
        gridObjects = new TGridObject[width, height];
        
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                gridObjects[x, z] = createGridObject(this, gridPosition);
            }
        }
        
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(Mathf.RoundToInt(worldPosition.x / cellSize),
            Mathf.RoundToInt(worldPosition.z / cellSize));
    }

    public void CreateGridObjects(Transform testPrefab)
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                
                Transform debugTransform = GameObject.Instantiate(testPrefab,GetWorldPosition(gridPosition),Quaternion.identity);
                GridObjectDebug gridObjectDebug = debugTransform.GetComponent<GridObjectDebug>();
                gridObjectDebug.SetGridObject(GetGridObject(gridPosition) as GridObject);
            }
        }
        
        
    }

    public TGridObject GetGridObject(GridPosition gridPosition)
    {
        return gridObjects[gridPosition.x, gridPosition.z];
    }
}
