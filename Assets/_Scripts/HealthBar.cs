/*--------------------------------------------------------------
// HealthBar.cs
//
// Process showing player healthbar on screen.
//
// Created by Tran Minh Son on Oct 25 2020
// StudentID: 101137552
// Date last Modified: Oct 25 2020
// Rev: 1.1
//  
// Copyright © 2020 Tran Minh Son. All rights reserved.
--------------------------------------------------------------*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = PlayerController.healthAmount/100;
        transform.localScale = localScale;
    }
}
