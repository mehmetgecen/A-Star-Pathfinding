using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private GameObject characterPrefab;
    
    private Vector3 targetPosition;
    private float stopDistance = .1f;
    private Animator _animator;

    private void Start()
    {
        _animator = characterPrefab.GetComponent<Animator>();
    }

    void Update()
    {
        transform.LookAt(MouseWorld.GetPosition());
        
        if (Vector3.Distance(transform.position,targetPosition) > stopDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float movementSpeed = 2f;
            transform.position += moveDirection * movementSpeed * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position,targetPosition) < stopDistance)
        {
            _animator.SetBool("startWalk",false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Move(MouseWorld.GetPosition());
            _animator.SetBool("startWalk",true);
        }
        
        
    }

    void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
    
}
