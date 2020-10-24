/*--------------------------------------------------------------
// BackButtonBehaviour.cs
//
// Handle the event when pressing the Back Button in Instruction Scene.
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

public class BackButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Event handler for BackButtonPressed Event
    public void OnBackButtonPressed()
    {
        Debug.Log("Back Button");
        SceneManager.LoadScene("MainMenu");
    }
}
