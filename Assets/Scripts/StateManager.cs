using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance;
    [SerializeField] public LevelConfig config;
    public GameState gameState;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        
        
    }

    private void Start()
    {
        gameState = GameState.ReadyToLaunch;
    }
}
