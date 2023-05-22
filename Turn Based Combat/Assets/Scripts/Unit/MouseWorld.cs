using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance;
    
    [SerializeField] private LayerMask mouseLayerMask;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        transform.position = MouseWorld.GetPosition();
    }

    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray,out RaycastHit hit,float.MaxValue,instance.mouseLayerMask);
        return hit.point;
    }
}
