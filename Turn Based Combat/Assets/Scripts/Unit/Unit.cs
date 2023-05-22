using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;
    
    private Vector3 targetPosition;
    private float stopDistance = .1f;
   
    
    void Update()
    {
        transform.LookAt(MouseWorld.GetPosition());
        
        if (Vector3.Distance(transform.position,targetPosition) > stopDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float movementSpeed = 2f;
            transform.position += moveDirection * movementSpeed * Time.deltaTime;
        }
        else
        {
            unitAnimator.SetBool("startWalk",false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Move(MouseWorld.GetPosition());
            unitAnimator.SetBool("startWalk",true);
        }
        
        
    }

    void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
    
}
