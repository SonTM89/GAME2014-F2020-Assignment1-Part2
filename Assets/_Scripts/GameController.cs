/*--------------------------------------------------------------
// GameController.cs
//
// Process objects inside GamePlay scene
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

public class GameController : MonoBehaviour
{
    [Header("Fireball Related")]
    public int MaxFireballs;
    public FireballType fireballType;

    // Start is called before the first frame update
    void Start()
    {
        // Prepare Fireball pool using by Player
        FireballManager.Instance().Init(MaxFireballs, fireballType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
