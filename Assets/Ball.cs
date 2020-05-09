using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioSource Hit;
    public AudioSource Caught;
    public GameObject ball;
    private GameObject ballClone;
    private List<GameObject> balls = new List<GameObject>();
    private int _timeCount = 30;
    private int _timeToCreate = 30;
    private int maxBalls = 30;

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
        return _timeCount >= _timeToCreate;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        //GetComponent<AudioSource>().Play();
        //Hit.Play();
    }
}
