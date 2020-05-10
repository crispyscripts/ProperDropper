using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    public GameObject ball;
    public int _timeToCreateNewBall = 15;
    public int maxBalls = 60;

    private GameObject ballClone;
    private List<GameObject> balls = new List<GameObject>();
    private int _timeCount = 30;

    private void FixedUpdate()
    {
        _timeCount++;

        if (TimeToCreateNewBall())
        {
            CreateNewBall();
            _timeCount = 0;
        }
    }

    private void Update()
    {
        if (balls.Count > 0)
        {
            foreach (var createdBall in balls)
            {
                if (createdBall != null)
                {
                    if (Camera.main.WorldToViewportPoint(createdBall.transform.position).y <= 0)
                    {
                        Destroy(createdBall);
                    }
                }
            }
            balls.RemoveAll(x => x == null);
        }
    }

    private bool TimeToCreateNewBall()
    {
        return _timeCount >= _timeToCreateNewBall;
    }

    // create randomised ball
    void CreateNewBall()
    {
        if (balls.Count < maxBalls)
        {
            var randomX = Random.Range(0f, 1f);

            var startPosition = Camera.main.ViewportToWorldPoint(new Vector3(randomX, 1, 0));

            ballClone = Instantiate(ball, startPosition, Quaternion.identity);

            balls.Add(ballClone);
        }
    }
}
