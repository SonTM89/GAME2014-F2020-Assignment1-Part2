/*--------------------------------------------------------------
// FireballFactory.cs
//
// Initiate a Fireball depends on what type of Fireball
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
using UnityEngine.UIElements;

public class FireballFactory
{
    private static FireballFactory m_instance = null;

    private FireballFactory()
    {
        _Initialize();
    }

    public static FireballFactory Instance()
    {
        if (m_instance == null)
        {
            m_instance = new FireballFactory();
        }

        return m_instance;
    }

    // Prefab references
    private GameObject playerFireball;
    private GameObject enemyFireball;

    // Game controller reference
    private GameController gameController;

    // Load prefabs using for instantiating any types of Fireball
    private void _Initialize()
    {
        playerFireball = Resources.Load("Prefabs/Fireball") as GameObject;
        enemyFireball = Resources.Load("Prefabs/E_Fireball") as GameObject;

        gameController = GameController.FindObjectOfType<GameController>();
    }


    // Initiate a Fireball depends on what type of Fireball
    public GameObject createFireball(FireballType type = FireballType.RANDOM)
    {
        if (type == FireballType.RANDOM)
        {
            var randomFireball = Random.Range(0, 2);
            type = (FireballType)randomFireball;
        }

        GameObject tempFireball = null;
        switch (type)
        {
            case FireballType.PLAYER_FIREBALL:
                tempFireball = MonoBehaviour.Instantiate(playerFireball);
                tempFireball.GetComponent<FireballController>().damage = 10;
                break;
            case FireballType.ENEMY_FIREBALL:
                tempFireball = MonoBehaviour.Instantiate(enemyFireball);
                tempFireball.GetComponent<FireballController>().damage = 5;
                break;
        }

        if(gameController != null)
        {
            tempFireball.transform.parent = gameController.gameObject.transform;
        }       
        tempFireball.SetActive(false);

        return tempFireball;
    }
}
