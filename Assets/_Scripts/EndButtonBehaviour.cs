/*--------------------------------------------------------------
// EndButtonBehaviour.cs
//
// Handle the event when pressing the End Button in GamePlay Scene.
//
// Created by Tran Minh Son on Oct 03 2020
// StudentID: 101137552
// Date last Modified: Oct 04 2020
// Rev: 1.0
//  
// Copyright © 2020 Tran Minh Son. All rights reserved.
--------------------------------------------------------------*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Event handler for EndButtonPressed Event
    public void OnEndButtonPressed()
    {
        Debug.Log("End Button");
        SceneManager.LoadScene("GameOver");
    }
}
