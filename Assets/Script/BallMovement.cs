using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [HideInInspector]
    public new Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigidbody.velocity = rigidbody.velocity.normalized * moveSpeed * Time.deltaTime;
    }
}
