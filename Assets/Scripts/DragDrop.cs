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
                Collider2D[] foundObjects = Physics2D.OverlapPointAll(mousePos);
                foreach(Collider2D foundObject in foundObjects){
                    if(foundObject.tag == "plant"){
                        draggableObject = foundObject.gameObject;
                        break;
                    }
                }
                if(draggableObject == null){
                    return;
                }
            }
            catch (System.Exception)
            {
                return;
            }
            Debug.Log("Clicked on " + draggableObject.name + " with tag" + draggableObject.tag);
            this.startPos = mousePos;
            Debug.Log("Can move " + draggableObject.name);
            this.dragging = true;
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
                        Collider2D[] contents = Physics2D.OverlapPointAll(collider.transform.position);
                        bool occupied = false;
                        foreach (Collider2D content in contents)
                        {
                            if (content.gameObject != draggableObject && content.tag == "plant")
                            {
                                Debug.Log("Cannot snap " + draggableObject.name + " to " + collider.name + " because it is occupied by " + content.name);
                                occupied = true;
                                break;
                            }
                        }
                        if (!occupied){
                            Debug.Log("Snapping " + draggableObject.name +" to grid at " + collider.transform.position);
                            // If it is, snap to grid
                            draggableObject.transform.position = collider.transform.position;
                            snap = true;
                        }
                    }
                }
                if(!snap){
                    Debug.Log("Snapping " + draggableObject.name +" to start position at " + startPos);
                    draggableObject.transform.position = this.startPos;
                }
                dragging = false;
                draggableObject = null;
            }
        }
    }
}
