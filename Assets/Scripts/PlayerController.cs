using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 input;
    private Vector3 _targetPos;
    private Animator myAnim;
    public float speed;

    private bool isMoving;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        myAnim.SetBool("isMoving",isMoving);
        _targetPos = transform.position;
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        if (input.x != 0) input.y = 0;
        if (input != Vector2.zero)
        {
            myAnim.SetFloat("moveX",input.x);
            myAnim.SetFloat("moveY",input.y);
            _targetPos.x += input.x;
            _targetPos.y += input.y;
            if (!isMoving)
            {
                StartCoroutine(Move(_targetPos));

            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        myAnim.SetBool("isMoving",isMoving);

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            targetPos = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            transform.position = targetPos;
            
        }
        isMoving = false;
        yield return null;
        
    }
}
