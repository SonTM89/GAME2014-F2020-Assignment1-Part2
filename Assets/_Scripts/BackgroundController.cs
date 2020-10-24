/*--------------------------------------------------------------
// StartButtonBehaviour.cs
//
// Control the background behaviour
//
// Created by Tran Minh Son on Oct 24 2020
// StudentID: 101137552
// Date last Modified: Oct 24 2020
// Rev: 1.1
//  
// Copyright © 2020 Tran Minh Son. All rights reserved.
--------------------------------------------------------------*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;


    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    // Reset position of background to the top boundary of the screen
    private void _Reset()
    {
        transform.position = new Vector3(0.0f, verticalBoundary);
    }

    // Move background gradually down to the bottom of the screen
    private void _Move()
    {
        transform.position -= new Vector3(0.0f, verticalSpeed) * Time.deltaTime;
    }

    // Check if the background go off the screen, reset its position
    private void _CheckBounds()
    {
        // if the background is lower than the bottom of the screen then reset
        if (transform.position.y <= -verticalBoundary)
        {
            _Reset();
        }
    }
}
