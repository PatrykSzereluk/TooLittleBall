using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{

    [SerializeField]
    private BallMovement ballPrefab;
    [SerializeField]
    private float delayBetweenBalls;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private DrawLine drawLine;

    private int ballsCount;
    private List<BallMovement> balls;

    private GameState gameState;

    private void Awake()
    {
        drawLine = GetComponent<DrawLine>();
        balls = new List<BallMovement>();
    }

    private void Start()
    {
        CreateBall();
        CreateBall();
        CreateBall();

        gameState = GameState.none;
    }

    private void CreateBall()
    {
        var tmp = Instantiate(ballPrefab);
        balls.Add(tmp);
        ballsCount++;
    }

    private void Update()
    {
        switch (gameState)
        {

            case GameState.none:
                {

                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + (Vector3.back * -10);

                    if (Input.GetMouseButtonDown(0))
                    {
                        StartDrag(worldPosition);
                    }
                    else if (Input.GetMouseButton(0))
                    {

                        ContinueDragging(worldPosition);
                    }
                    else if (Input.GetMouseButtonUp(0))
                    {

                        EndDragging();
                    }

                    break;
                }
        }
    }

    private void EndDragging()
    {
        drawLine.ResetLine();

        gameState = GameState.launch;

        StartCoroutine(LaunchBalls());
    }

    private void ContinueDragging(Vector3 worldPosition)
    {
        endPosition = worldPosition;

        Vector3 direction = endPosition - startPosition;

        drawLine.SetEndPoint(transform.position - direction);

    }

    private void StartDrag(Vector3 worldPosition)
    {
        startPosition = worldPosition;

        drawLine.SetStartPoint(transform.position);
    }

    private  IEnumerator LaunchBalls()
    {
        Vector3 direction = endPosition - startPosition;
        direction.Normalize();
       
        foreach(var ball in balls)
        {
            ball.gameObject.SetActive(true);
            ball.transform.position = transform.position;
            ball.rigidbody.AddForce(-direction);

            yield return new WaitForSeconds(delayBetweenBalls);
        }

        ballsCount = 0;

    }

    public void BallReturned()
    {
        ballsCount++;

        if (ballsCount.Equals(balls.Count))
        {
            CreateBall();
            gameState = GameState.none;
        }
    }


}
