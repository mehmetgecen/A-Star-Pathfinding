using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PathfindingGridDebugObject : GridObjectDebug
{
    [SerializeField]private TextMeshPro gCostText;
    [SerializeField]private TextMeshPro hCostText;
    [SerializeField]private TextMeshPro fCostText;

    private PathNode pathNode;

    public override void SetGridObject(object gridObject)
    {
        base.SetGridObject(gridObject);
        pathNode = (PathNode)gridObject;
        
    }

    protected override void Update()
    {
        base.Update();
        gCostText.text = String.Format("{0:00}",pathNode.GetGCost().ToString());
        hCostText.text = String.Format("{0:00}",pathNode.GetHCost().ToString());
        fCostText.text = String.Format("{0:00}",pathNode.GetFCost().ToString());
    }
}
