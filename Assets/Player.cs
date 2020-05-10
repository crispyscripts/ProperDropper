using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Sprite ClosedFist;
    public Sprite OpenFist;
    public AudioClip CaughtBall;
    public AudioSource audioSource;

    bool mouseDown;

    // Update is called once per frame
    void Update()
    {
        if (mouseDown)
        {
            var newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(newPosition.x, transform.position.y);
        }
    }

    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = OpenFist;
        GetComponent<Collider2D>().enabled = false;
        mouseDown = true;
    }

    void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = ClosedFist;
        GetComponent<Collider2D>().enabled = true;
        mouseDown = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!mouseDown && WithinBounds(collision.collider, GetComponent<Collider2D>()))
        {
            audioSource.clip = CaughtBall;
            audioSource.Play();
            Destroy(collision.collider.gameObject);
            Score.UpdateScore();
        }
    }

    private bool WithinBounds(Collider2D ball, Collider2D player)
    {
        var ballCenter = ball.bounds.center;
        var playerCenter = player.bounds.center;

        return (ballCenter.y >= playerCenter.y - 1 && ballCenter.y <= playerCenter.y + 1
            && ballCenter.x >= playerCenter.x - 1 && ballCenter.x <= playerCenter.x + 1);
    }
}
