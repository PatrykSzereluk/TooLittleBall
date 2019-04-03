using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehaviour : MonoBehaviour
{

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            STF.ballLauncher.BallReturned();
            collision.collider.gameObject.SetActive(false);
        }

        if (collision.collider.CompareTag("Block"))
        {
            STF.gameManager.gameState = GameState.gameover;

            STF.gameManager.gameOverMenu.SetActive(true);
        }
    }

   

}
