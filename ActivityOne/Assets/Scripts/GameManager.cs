using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver;
    private static GameManager _instance;

    public static GameManager Instance
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

    public void GameRestart(bool dead)
    {
        _isGameOver = dead;
    }

    public IEnumerator DisplayScene()
    {
        Debug.Log("Try Again!");
        yield return null;
    }
}

