/*--------------------------------------------------------------
// InstructionButtonBehaviour.cs
//
// Handle the event when pressing the Instruction Button in MainMenu Scene.
//
// Created by Tran Minh Son on Oct 03 2020
// StudentID: 101137552
// Date last Modified: Oct 23 2020
// Rev: 1.1
//  
// Copyright © 2020 Tran Minh Son. All rights reserved.
--------------------------------------------------------------*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionButtonBehaviour : MonoBehaviour
{
    // button click sound
    public AudioSource clickSound;


    // Event handler for InstructionButtonPressed Event
    // Play sound when click button and change to Instruction scene
    public void OnInstructionButtonPressed()
    {
        clickSound.Play();
        Debug.Log("Instruction show!");
        StartCoroutine(LoadLevel("Instruction", 0.3f));
    }

    // Waiting for _delay seconds to load new scene
    IEnumerator LoadLevel(string _name, float _delay)
    {
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(_name);
    }
}
