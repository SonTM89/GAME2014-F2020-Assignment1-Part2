/*--------------------------------------------------------------
// RestartButtonBehaviour.cs
//
// Handle the event when pressing the Restart Button in GameOver Scene.
//
// Created by Tran Minh Son on Oct 03 2020
// StudentID: 101137552
// Date last Modified: Oct 24 2020
// Rev: 1.1
//  
// Copyright © 2020 Tran Minh Son. All rights reserved.
--------------------------------------------------------------*/


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonBehaviour : MonoBehaviour
{
    // button click sound
    public AudioSource clickSound;

    // reference to score UI
    public TextMeshProUGUI totalScore;

    // Show player score on screen
    void Start()
    {
        totalScore.text = ScoreManager.Instance().playerScore.ToString();
    }

    // Event handler for RestartButtonPressed Event
    public void OnRestartButtonPressed()
    {
        clickSound.Play();
        Debug.Log("Restart!");
        StartCoroutine(LoadLevel("GamePlay", 0.3f));
    }

    // Waiting for _delay seconds to load new scene
    IEnumerator LoadLevel(string _name, float _delay)
    {
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(_name);
    }
}
