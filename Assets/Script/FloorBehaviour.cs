﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehaviour : MonoBehaviour
{

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            STF.ballLauncher.BallReturned();
            //collision.collider.gameObject.GetComponent<Collider2D>().enabled = false;
            //collision.collider.gameObject.GetComponent<SpriteRenderer>().enabled = false;

            collision.collider.gameObject.SetActive(false);
        }
        else if (collision.collider.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
        }
    }


    
}
