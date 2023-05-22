using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;
    
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private float stopDistance = .1f;
    
    private Vector3 targetPosition;
    
    void Update()
    {
        //transform.LookAt(MouseWorld.GetPosition());
        
        if (Vector3.Distance(transform.position,targetPosition) > stopDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            
            transform.position += moveDirection * movementSpeed * Time.deltaTime;
            unitAnimator.SetBool("startWalk",true);

            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
        }
        else
        {
            unitAnimator.SetBool("startWalk",false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Move(MouseWorld.GetPosition());
            
        }
        
        
    }

    void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
    
}
