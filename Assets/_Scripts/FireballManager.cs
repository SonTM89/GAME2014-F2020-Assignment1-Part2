/*--------------------------------------------------------------
// FireballManager.cs
//
// Manage the Fireball pool
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

[System.Serializable]
public class FireballManager
{
    private static FireballManager m_instance = null;

    public static FireballManager Instance()
    {
        if (m_instance == null)
        {
            m_instance = new FireballManager();
        }

        return m_instance;
    }

    public int MaxFireballs { get; set; }

    private Queue<GameObject> m_fireballPool;
    private Queue<GameObject> m_enemyFireballPool;


    // Create a Fireball pool belongs to input type and number of fireball as well
    public void Init(int max_fireballs = 50, FireballType type = FireballType.PLAYER_FIREBALL, FireballType eType = FireballType.ENEMY_FIREBALL)
    {
        MaxFireballs = max_fireballs;
        _BuildFireballPool(type);
        _BuildEnemyFireballPool(eType);
    }


    /*-----------------------PLAYER FIREBALL POOL----------------------------------*/

    // Build Fireball pool
    private void _BuildFireballPool(FireballType type)
    {
        // create empty Queue structure
        m_fireballPool = new Queue<GameObject>();

        for (int count = 0; count < MaxFireballs; count++)
        {
            var tempFireball = FireballFactory.Instance().createFireball(type);
            m_fireballPool.Enqueue(tempFireball);
        }
    }

    // Get a Fireball from pool to process
    public GameObject GetFireball(Vector3 position)
    {
        var newFireball = m_fireballPool.Dequeue();
        newFireball.SetActive(true);
        newFireball.transform.position = position;
        return newFireball;
    }

    // Check the remaining Fireballs inside pool
    public bool HasFireballs()
    {
        return m_fireballPool.Count > 0;
    }

    // Return fireball back to Fireball pool
    public void ReturnFireball(GameObject returnedFireball)
    {
        returnedFireball.SetActive(false);
        m_fireballPool.Enqueue(returnedFireball);
    }
    /*----------------------------------------------------------------------------*/


    /*-----------------------ENEMY FIREBALL POOL----------------------------------*/

    // Build Enemy Fireball pool
    private void _BuildEnemyFireballPool(FireballType eType)
    {
        // create empty Queue structure
        m_enemyFireballPool = new Queue<GameObject>();

        for (int count = 0; count < MaxFireballs; count++)
        {
            var tempFireball = FireballFactory.Instance().createFireball(eType);
            tempFireball.transform.Rotate(0.0f, 0.0f, 180.0f, Space.World);
            m_enemyFireballPool.Enqueue(tempFireball);
        }
    }

    // Get an Enemy Fireball from pool to process
    public GameObject GetEnemyFireball(Vector3 position)
    {
        var newFireball = m_enemyFireballPool.Dequeue();
        newFireball.SetActive(true);
        newFireball.transform.position = position;
        return newFireball;
    }

    // Check the remaining Enemy Fireballs inside pool
    public bool HasEnemyFireballs()
    {
        return m_enemyFireballPool.Count > 0;
    }

    // Return Enemy fireball back to Enemy Fireball pool
    public void ReturnEnemyFireball(GameObject returnedFireball)
    {
        returnedFireball.SetActive(false);
        m_enemyFireballPool.Enqueue(returnedFireball);
    }
    /*----------------------------------------------------------------------------*/
}
