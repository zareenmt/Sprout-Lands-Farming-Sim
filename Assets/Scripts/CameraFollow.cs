using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Vector3 camOffset;
    
    void Start()
    {
        camOffset = transform.position - _target.position;
    }

    private void FixedUpdate()
    {
        transform.position = _target.position + camOffset;
    }
}
