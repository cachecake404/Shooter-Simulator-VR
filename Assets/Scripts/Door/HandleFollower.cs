﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleFollower : MonoBehaviour
{
    public Transform target;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(target.transform.position);
    }
}
