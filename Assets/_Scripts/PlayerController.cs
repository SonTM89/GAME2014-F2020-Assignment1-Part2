﻿/*--------------------------------------------------------------
// PlayerController.cs
//
// Control the player behaviour such as moving,firing, colliding etc.
//
// Created by Tran Minh Son on Oct 24 2020
// StudentID: 101137552
// Date last Modified: Oct 25 2020
// Rev: 1.1
//  
// Copyright © 2020 Tran Minh Son. All rights reserved.
--------------------------------------------------------------*/


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Boundary Check")]
    public float horizontalBoundary;

    [Header("Player Speed")]
    public float horizontalSpeed;
    public float maxSpeed;
    public float horizontalTValue;

    [Header("Bullet Firing")]
    public float fireDelay;

    [Header("Score Display")]
    public TextMeshProUGUI playerScoreDisplay;

    public static float healthAmount;

    public AudioSource shootingSound;
    public AudioSource collectingSound;
    public AudioSource explodingSound;

    private Rigidbody2D m_rigidBody; // player rigidbody 2D

    private Vector3 m_touchesEnded; // position of touch input

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Instance().playerScore = 0;
        healthAmount = 100;

        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>(); // Get rigidbody of the player
    }

    // Update is called once per frame
    void Update()
    {
        playerScoreDisplay.text = "Score: " + ScoreManager.Instance().playerScore.ToString();

        _Move();
        _CheckBounds();
        _FireballFire();

        if(healthAmount <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    // Moving player along X-axis and within the screen boundaries
    private void _Move()
    {
        float direction = 0.0f;

        // Touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.x > transform.position.x)
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.x < transform.position.x)
            {
                // direction is negative
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }

        // Keyboard support
        if (Input.GetAxis("Horizontal") >= 0.1f)
        {
            // direction is positive
            direction = 1.0f;
        }

        if (Input.GetAxis("Horizontal") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        // Move player using touch input
        if (m_touchesEnded.x != 0.0f)
        {
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, m_touchesEnded.x, horizontalTValue), transform.position.y);
        }
        // Move player using keyboard input
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(direction * horizontalSpeed, 0.0f);
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }

    // Check left and right boundaries to not allow player to go off the screen
    private void _CheckBounds()
    {
        // check right bounds
        if (transform.position.x >= horizontalBoundary)
        {
            transform.position = new Vector3(horizontalBoundary, transform.position.y, 0.0f);
        }

        // check left bounds
        if (transform.position.x <= -horizontalBoundary)
        {
            transform.position = new Vector3(-horizontalBoundary, transform.position.y, 0.0f);
        }

    }

    private void _FireballFire()
    {
        // delay fireball firing 
        if (Time.frameCount % 10 == 0 && FireballManager.Instance().HasFireballs())
        {
            shootingSound.Play();
            FireballManager.Instance().GetFireball(transform.position);
        }
    }

    // Player health will be decreased when colliding with Enemy Fireball and will be destroyed when health amount <= 0
    // Player will be destroyed when colliding with Enemies
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Gem")
        {
            collectingSound.Play();
        }

        if (col.gameObject.tag == "E_Fireball")
        {
            Debug.Log(healthAmount);
            healthAmount -= FireballDamage.ENEMY_FIREBALL;
        }

        if (col.gameObject.tag == "Enemy" || healthAmount <= 0)
        {
            explodingSound.Play();
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
