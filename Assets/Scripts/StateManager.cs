﻿using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance;
    [SerializeField] public LevelConfig config;
    public GameState gameState;
    public GameObject currentBird;
    public int remainingPigs;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        remainingPigs = config.remainedPigs;

    }

    private void Start()
    {
        Time.timeScale = 1;
        gameState = GameState.ReadyToLaunch;
    }

    private void Update()
    {
        
    }
}
