using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Ball"))
        {

            STF.ballLauncher.ballsToAddInNextRound++;

            Destroy(gameObject);
        }

    }
}
