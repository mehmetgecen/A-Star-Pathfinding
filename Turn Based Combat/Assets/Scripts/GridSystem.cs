using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    private int width;
    private int height;
    private float cellSize;
    private GridObject[,] gridObjects;
    
    public GridSystem(int width,int height,float cellSize)
    {
        this.height = height;
        this.width = width;
        this.cellSize = cellSize;

        gridObjects = new GridObject[width, height];
        
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                gridObjects[x, z] = new GridObject(this, gridPosition);
            }
        }
        
    }

    public Vector3 GetWorldPosition(int x , int z)
    {
        return new Vector3(x, 0, z) * cellSize;
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
                GameObject.Instantiate(testPrefab,GetWorldPosition(x,z),Quaternion.identity);        
            }
        }
        
        
    }
}
