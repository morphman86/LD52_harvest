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
            this.startPos = mousePos;
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
                        Grid gridSlot = collider.GetComponent<Grid>();
                        if (gridSlot.IsEmpty(draggableObject.GetComponent<Collider2D>())) {
                            // If the gridslot is of type sell, destroy the plant
                            if (gridSlot.GetGridType() == Grid.GridType.Sell)
                            {
                                Destroy(draggableObject);
                            }
                            // If it is, snap to grid
                            draggableObject.transform.position = collider.transform.position;
                            snap = true;
                        }
                    }
                }
                if(!snap){
                    draggableObject.transform.position = this.startPos;
                }
                dragging = false;
                draggableObject = null;
            }
        }
    }
}
