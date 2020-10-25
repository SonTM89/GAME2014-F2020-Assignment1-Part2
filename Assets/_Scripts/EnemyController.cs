/*--------------------------------------------------------------
// EnemyController.cs
//
// Control enemies behaviour such as moving and firing etc.
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

public class EnemyController : MonoBehaviour, IApplyDamage
{
    public float verticalSpeed;
    public float verticalBoundary;
    public float horizontalSpeed;
    public float horizontalBoundary;
    public float direction;
    public int enemyHealth;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        _FireballFire();
    }

    private void _Move()
    {
        transform.position += new Vector3(/*horizontalSpeed * direction * Time.deltaTime*/ 0.0f, verticalSpeed * Time.deltaTime, 0.0f);
    }

    private void _CheckBounds()
    {
        // check right boundary
        if (transform.position.x >= horizontalBoundary)
        {
            direction = -1.0f;
        }

        // check left boundary
        if (transform.position.x <= -horizontalBoundary)
        {
            direction = 1.0f;
        }

        if(transform.position.y <= -verticalBoundary)
        {
            Destroy(gameObject);
        }
    }

    // Friring Fireball
    public void _FireballFire()
    {
        // delay enemy fireball firing 
        if (Time.frameCount % 120 == 0 && FireballManager.Instance().HasEnemyFireballs())
        {
            FireballManager.Instance().GetEnemyFireball(transform.position);
        }
    }

    // Enemy health will be decrease when colliding with player fireball
    // When enymy health amount <= 0, enemy will be destroyed and give points to player
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Fireball" && col.gameObject.transform.position.y < 5.2f)
        {
            enemyHealth -= ApplyDamage();
            if (enemyHealth <= 0)
            {
                ScoreManager.Instance().playerScore += ScoreManager.ENEMY_POINT;
                Destroy(gameObject);
            }
        }
    }

    public int ApplyDamage()
    {
        return FireballDamage.PLAYER_FIREBALL;
    }
}
