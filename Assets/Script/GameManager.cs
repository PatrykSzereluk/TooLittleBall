﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float timeToIncreaseTimeScale = 5f;
    private float _timeToIncreaseTimeScale;

    [SerializeField]
    private float timeToTurnOnGravity = 12f;
    private float _timeToTurnOnGravity;

    public GameState gameState;

    private void Awake()
    {
        _timeToIncreaseTimeScale = timeToIncreaseTimeScale;
        _timeToTurnOnGravity = timeToTurnOnGravity;
    }

    public void ChangeTimeScale(int timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void ChangeGravity(float gravityForce)
    {
        var BallsList = STF.ballLauncher.balls;

        foreach (var item in BallsList)
        {
            if (item.rigidbody != null)
                item.rigidbody.gravityScale = gravityForce;
        }

        

    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.launch:
                {
                    _timeToIncreaseTimeScale -= Time.deltaTime;

                    _timeToTurnOnGravity -= Time.deltaTime;

                    if (_timeToIncreaseTimeScale <= 0)
                    {
                        ChangeTimeScale(2);
                    }

                    if (_timeToTurnOnGravity <= 0)
                    {
                        ChangeGravity(0.1f);
                    }

                    break;
                }
            case GameState.aiming:
                {
                    _timeToIncreaseTimeScale = timeToIncreaseTimeScale;
                    _timeToTurnOnGravity = timeToTurnOnGravity;

                    ChangeTimeScale(1);
                    ChangeGravity(0);

                    break;
                }
        }
    }


}