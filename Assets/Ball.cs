using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Ball : MonoBehaviour
{
    public AudioClip Hit;
    public AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.otherCollider.tag != "Player")
        //{
        //    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        //    return;
        //}

        audioSource.clip = Hit;
        audioSource.Play();
    }
}
