using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public bool canMove;
    public bool dragging;
    Collider2D thisCollider;
    void Start()
    {
        thisCollider = gameObject.GetComponent<Collider2D>();
        canMove = false;
        dragging = false;

    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            canMove = thisCollider == Physics2D.OverlapPoint(mousePos);
            if (canMove)
            {
                dragging = true;
            }
        }
        if (dragging)
        {
            this.transform.position = mousePos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
            dragging = false;
        }
    }
}
