using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctionality : MonoBehaviour
{
   

    public void OnExitButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OnRetryButton()
    {
        SceneManager.LoadScene(1);
    }


}
