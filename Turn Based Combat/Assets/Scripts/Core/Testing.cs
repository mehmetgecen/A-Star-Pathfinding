using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Unit unit;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.GetPosition());
            GridPosition startGridPosition = unit.GetGridPosition();

            List<GridPosition> gridPositionList = Pathfinding.Instance.FindPath(startGridPosition, mouseGridPosition);

            for (int i = 0; i < gridPositionList.Count-1; i++)
            {
               Debug.DrawLine(LevelGrid.Instance.GetWorldPosition(gridPositionList[i]),
                   LevelGrid.Instance.GetWorldPosition(gridPositionList[i+1]),Color.green,5f);
            }
        }
    }
}
