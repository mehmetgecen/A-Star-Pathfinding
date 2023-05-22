using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    [SerializeField] private LayerMask mouseLayerMask;
   
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log(Physics.Raycast(ray,out RaycastHit hit,float.MaxValue,mouseLayerMask));
        transform.position = hit.point;
    }
}
