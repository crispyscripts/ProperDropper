using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public Sprite ClosedFist;
    public Sprite OpenFist;
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
}
