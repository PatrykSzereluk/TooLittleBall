using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class STF
{

    private static BallLauncher _ballLauncher;

    public static BallLauncher ballLauncher
    {
        get
        {
            return _ballLauncher ?? (
                _ballLauncher = GameObject.FindGameObjectWithTag("BallLauncher")
                .GetComponent<BallLauncher>());
        }
    }

    private static BlockManager _blockManager;

    public static BlockManager blockManager
    {
        get
        {
            return _blockManager ?? (_blockManager = GameObject.FindGameObjectWithTag("BlockManager")
                .GetComponent<BlockManager>());
        }
    }

    private static UIManager _uimanager;

    public static UIManager uimanager
    {
        get
        {
            return _uimanager ?? (_uimanager = GameObject.FindGameObjectWithTag("UIManager")
                .GetComponent<UIManager>());
        }
    }

    private static GameManager _gameManager;

    public static GameManager gameManager
    {
        get
        {
           return _gameManager ?? (_gameManager = GameObject.FindGameObjectWithTag("GameController")
                .GetComponent<GameManager>());
        }
    }

}
