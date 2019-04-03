using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(DrawLine))]
public class BallLauncher : MonoBehaviour
{

    [SerializeField]
    private BallMovement ballPrefab = null;

    [SerializeField]
    private float delayBetweenBalls = 0;


    private Vector3 startPosition;
    private Vector3 endPosition;
    private DrawLine drawLine;

    private int ballsCount;

    [HideInInspector]
    public List<BallMovement> balls;

    [Header("BugSeciurity")]
    [SerializeField]
    private bool isClickLeftButton = false;

    private void Awake()
    {
        drawLine = GetComponent<DrawLine>();
        balls = new List<BallMovement>();
    }

    private void Start()
    {
        CreateBall();
    }

    private void CreateBall()
    {
        var tmp = Instantiate(ballPrefab);
        balls.Add(tmp);
        ballsCount++;
    }

    private void Update()
    {
        switch (STF.gameManager.gameState)
        {

            case GameState.aiming:
                {

                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + (Vector3.back * -10);

                    if (Input.GetMouseButtonDown(0))
                    {
                        StartDrag(worldPosition);
                        isClickLeftButton = true;
                    }
                    else if (Input.GetMouseButton(0) && isClickLeftButton)
                    {

                        ContinueDragging(worldPosition);
                    }
                    else if (Input.GetMouseButtonUp(0) && isClickLeftButton)
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

        STF.gameManager.gameState = GameState.launch;

        isClickLeftButton = false;

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

            ballsCount--;

            yield return new WaitForSeconds(delayBetweenBalls);
        }

        

    }

    public void BallReturned()
    {
        ballsCount++;
        
        if (ballsCount == balls.Count)
        {

            CreateBall();

            STF.gameManager.gameState = GameState.aiming;    
            STF.blockManager.CreateRowOfBlocks();
        }
    }


}
