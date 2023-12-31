using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver; //Bool to call when game state is over, initiating a reset.
    private static GameManager _instance; //instance bullshit i need to study more []

    public GameState State;

    public static event Action<GameState> OnGameStateChange;
    /* 
    #GameState Event is created to enable the game to know what state it is in. 
    (treating this area like a checkpoint)
    [Do think about adding checkpoints if neccessary]
    */

    public static GameManager Instance //GameManager function for initiating the start of the game and keeping track of it
    {
        get
        {
            if (_instance == null)
                Debug.Log("gamemanager instance is Null!");
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.Start);
    }

    public void GameRestart(bool dead)
    {
        _isGameOver = dead;
    }

    public IEnumerator DisplayScene()
    {
        Debug.Log("Try Again!");
        yield return null;
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch(newState)
        {
            case GameState.Start:
            StartGame();
            break;
            case GameState.Dead:
            break;
            case GameState.Danger:
            break;
            case GameState.Warning:
            break;
            default:
            throw new ArgumentOutOfRangeException(nameof(newState), newState, null);

        }

        OnGameStateChange?.Invoke(newState);
    }

    private void StartGame()
    {
        
    }
    
    public enum GameState {
        Start,
        Dead,
        Danger,
        Warning
    }


}

