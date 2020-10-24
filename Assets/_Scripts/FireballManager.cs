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


    // Create a Fireball pool belongs to input type and number of fireball as well
    public void Init(int max_fireballs = 50, FireballType type = FireballType.PLAYER_FIREBALL)
    {
        MaxFireballs = max_fireballs;
        _BuildFireballPool(type);
    }

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
}
