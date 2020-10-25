/*--------------------------------------------------------------
// GameController.cs
//
// Process objects inside GamePlay scene
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
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Fireball Related")]
    public int MaxFireballs;
    public FireballType fireballType;
    public FireballType enemyFireballType;

    // references to gem and enemy prefabs
    private GameObject gem;
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        gem = Resources.Load("Prefabs/Gem") as GameObject;
        enemy = Resources.Load("Prefabs/Enemy") as GameObject;

        // Prepare Fireball pool using by Player and Enemies
        FireballManager.Instance().Init(MaxFireballs, fireballType, enemyFireballType);       
    }

    // Update is called once per frame
    void Update()
    {
        // Randomize Enemy if their number is less than 5
        if(GameObject.FindGameObjectsWithTag("Enemy").Length < 5)
        {
            MonoBehaviour.Instantiate(enemy, new Vector3(Random.Range(-2.2f, 2.2f), 5.2f, 0.0f), Quaternion.identity);
        }

        // Randomize Gem every 1800 frame counts
        if (Time.frameCount % 1800 == 0)
        {
            MonoBehaviour.Instantiate(gem, new Vector3(Random.Range(-2.2f, 2.2f), Random.Range(0.0f, 3.5f), 0.0f), Quaternion.identity);
        }
    }
}
