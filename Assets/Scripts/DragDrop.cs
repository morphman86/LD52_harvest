using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public bool canMove;
    public bool dragging;
    GameObject draggableObject;
    public Vector2 startPos;
    void Start()
    {
        this.canMove = false;
        this.dragging = false;
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            try
            {
                draggableObject = Physics2D.OverlapPoint(mousePos).gameObject;
            }
            catch (System.Exception)
            {
                return;
            }
            Debug.Log("Clicked on " + draggableObject.name + " with tag" + draggableObject.tag);
            if(draggableObject.tag == "plant") canMove = true;
            // canMove = draggableObject.GetComponent<Collider>() == Physics2D.OverlapPoint(mousePos);
            if (canMove)
            {
                this.startPos = mousePos;
                Debug.Log("Can move " + draggableObject.name);
                this.dragging = true;
            }
        }
        if (this.dragging)
        {
            draggableObject.transform.position = mousePos;
            if (Input.GetMouseButtonUp(0))
            {
                // Check if object is intersecting with an object tagged with "grid"
                Collider2D[] colliders = Physics2D.OverlapPointAll(mousePos);
                bool snap = false;
                foreach (Collider2D collider in colliders)
                {
                    if (collider.tag == "grid")
                    {
                        Debug.Log("Snapping " + draggableObject.name +" to grid at " + collider.transform.position);
                        // If it is, snap to grid
                        draggableObject.transform.position = collider.transform.position;
                        snap = true;
                    }
                }
                if(!snap){
                    Debug.Log("Snapping " + draggableObject.name +" to start position at " + startPos);
                    draggableObject.transform.position = this.startPos;
                }
                canMove = false;
                dragging = false;
            }
        }
    }
}
