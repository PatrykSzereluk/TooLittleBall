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

            // collision.collider.transform.position = new Vector3(-2, -5, 0);

            collision.collider.gameObject.SetActive(false);
        }
        else if (collision.collider.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
        }
    }


    
}
