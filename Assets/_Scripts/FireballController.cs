/*--------------------------------------------------------------
// FireballController.cs
//
// Control Fireball behaviour such as moving, returning, colliding, dealing damage etc.
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

public class FireballController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;
    public int damage;

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

    // Fireball moves belong to verticalSpeed multiply deltaTime
    private void _Move()
    {
        transform.position += new Vector3(0.0f, verticalSpeed, 0.0f) * Time.deltaTime;
    }

    // Fireball will be returned to fireballPool when going off screen
    private void _CheckBounds()
    {
        if (transform.position.y > verticalBoundary || transform.position.y < -verticalBoundary)
        {
            FireballManager.Instance().ReturnFireball(gameObject);
        }
    }

    // Fireball will be returned to fireballPool when colliding with other objects
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);
        FireballManager.Instance().ReturnFireball(gameObject);
    }

    public int ApplyDamage()
    {
        return damage;
    }
}
