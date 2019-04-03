using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("HS"))
        {
            scoreText.text = PlayerPrefs.GetInt("HS").ToString();
        }
        else
        {
            scoreText.text = "0";
        }
    }



    public void OnLoadButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

    public void OnHighScoreButton()
    {
        Debug.Log("Not implemented yet!!!");
    }
}
