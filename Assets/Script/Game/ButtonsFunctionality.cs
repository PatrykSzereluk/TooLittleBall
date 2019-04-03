using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctionality : MonoBehaviour
{
   

    public void OnExitButton()
    {
        STF.gameManager.SetPoint();
        SceneManager.LoadScene(0);
    }

    public void OnRetryButton()
    {
        SceneManager.LoadScene(1);
    }

    public void Resume()
    {
        STF.gameManager.gameState = GameState.aiming;
        STF.gameManager.pauseMenu.SetActive(false);
    }

}
