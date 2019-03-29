using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float timeToIncreaseTimeScale = 5f;
    private float _timeToIncreaseTimeScale;

    public GameState gameState;

    private void Awake()
    {
        _timeToIncreaseTimeScale = timeToIncreaseTimeScale;
    }

    public void ChangeTimeScale(int timeScale)
    {
        Time.timeScale = timeScale;
        _timeToIncreaseTimeScale = timeToIncreaseTimeScale;
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.launch:
                {
                    _timeToIncreaseTimeScale -= Time.deltaTime;

                    if (_timeToIncreaseTimeScale <= 0)
                    {
                        ChangeTimeScale(2);
                    }
                    break;
                }
        }
    }


}
