using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;
    private float stopDistance = .1f;
    void Update()
    {
        if (Vector3.Distance(transform.position,targetPosition) > stopDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float movementSpeed = 4f;
            transform.position += moveDirection * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Move(new Vector3(4,0,4));
        }
    }

    void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}