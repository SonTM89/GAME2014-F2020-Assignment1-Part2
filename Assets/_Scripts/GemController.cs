/*--------------------------------------------------------------
// GemController.cs
//
// Control Gem behaviour such as moving and colliding.
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

public class GemController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    // Gems move down the screen
    private void _Move()
    {
        transform.position += new Vector3(0.0f, -verticalSpeed * Time.deltaTime, 0.0f);
    }

    // Gems will be destroyed when going off the screen
    private void _CheckBounds()
    {
        if (transform.position.y <= -verticalBoundary)
        {
            Destroy(gameObject);
        }
    }

    // Player will receice reward point when getting Gems
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            ScoreManager.Instance().playerScore += ScoreManager.REWARD_POINT;
            Destroy(gameObject);
        }
    }
}
