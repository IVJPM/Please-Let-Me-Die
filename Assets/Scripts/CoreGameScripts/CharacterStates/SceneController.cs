using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerManager;

public class SceneController : MonoBehaviour
{
    public static SceneController sceneInstance;

    [SerializeField] PlayerManager player;
    [SerializeField] EnemyController enemyController;

    public enum SceneState
    {
        OverworldState,
        CombatState
    }
    public SceneState currentSceneState;
    private void Awake()
    {
        if(sceneInstance == null)
        {
            sceneInstance = this;
        }
        else
        {
            Destroy(sceneInstance);
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
