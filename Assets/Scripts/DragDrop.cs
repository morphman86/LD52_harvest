using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public bool canMove;
    public bool dragging;
    GameObject draggableObject;
    public Vector2 startPos;
    private SoundHandler soundHandler;


    void Start()
    {
        soundHandler = GameObject.Find("game").GetComponent<SoundHandler>();
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
                                soundHandler.PlaySound("error");
                                Destroy(draggableObject);
                            }
                            // If it is, snap to grid
                            soundHandler.PlaySound("action");
                            draggableObject.transform.position = collider.transform.position - new Vector3(0, 0.25f, 0);
                            snap = true;
                        } else {
                            soundHandler.PlaySound("action");
                            //swap places with the plant in the grid slot
                            GameObject plantInGridSlot = gridSlot.GetPlant(draggableObject.GetComponent<Collider2D>());
                            plantInGridSlot.transform.position = this.startPos;
                            draggableObject.transform.position = collider.transform.position - new Vector3(0, 0.25f, 0);
                            snap = true;
                        }
                    }
                }
                if(!snap){
                    soundHandler.PlaySound("action");
                    draggableObject.transform.position = this.startPos;
                }
                dragging = false;
                draggableObject = null;
            }
        }
    }
}
