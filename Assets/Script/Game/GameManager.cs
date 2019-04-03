using System;
using System.Collections;
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

    private bool firstTime;

    public GameState gameState;

    public GameObject gameOverMenu;
    public GameObject pauseMenu;


    [Header("Test")]
    public BallLauncher balllauncher;
    public BlockManager blockmanager;
    public UIManager uimanager;

    

    private void Awake()
    {
        STF.NullReferences();
        balllauncher = STF.ballLauncher;
        blockmanager = STF.blockManager;
        uimanager = STF.uimanager;

        _timeToIncreaseTimeScale = timeToIncreaseTimeScale;
        _timeToTurnOnGravity = timeToTurnOnGravity;
        gameState = GameState.aiming;
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
                    firstTime = true;

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
                    if (firstTime)
                    {
                        _timeToIncreaseTimeScale = timeToIncreaseTimeScale;
                        _timeToTurnOnGravity = timeToTurnOnGravity;

                        ChangeTimeScale(1);
                        ChangeGravity(0);

                        firstTime = false;
                    }

                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        gameState = GameState.pause;
                        pauseMenu.SetActive(true);
                    }


                    break;
                }
            case GameState.pause:
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        gameState = GameState.aiming;
                        pauseMenu.SetActive(false);
                    }

                    break;
                }
            case GameState.gameover:
                {
                    STF.blockManager.SetAlphaChanelToBlocks(0.3f);
                    SetPoint();
                    gameOverMenu.SetActive(true);
                    break;
                }
        }
    }

    public void SetPoint()
    {

        if (PlayerPrefs.HasKey("HS"))
        {
            int currentHS = PlayerPrefs.GetInt("HS");

            if(currentHS < STF.blockManager.rowsSpawned)
            {
                PlayerPrefs.SetInt("HS", STF.blockManager.rowsSpawned);
            }

        }
        else
        {
            PlayerPrefs.SetInt("HS", STF.blockManager.rowsSpawned);
        }
    }
}
