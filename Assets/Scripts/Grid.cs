using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    // class to represent a grid slot
    // three grid types, planter, breed and sell
    public enum GridType
    {
        Planter,
        Breed,
        Sell
    }
    // grid type
    [SerializeField]
    private GridType gridType;
    // grid slot index
    private int index;
    // is empty
    private bool isEmpty;

    // Start is called before the first frame update
    void Start()
    {
        // set the grid slot index
        index = transform.GetSiblingIndex();
        // set the grid type
        if (transform.parent.name == "planterGrid")
        {
            gridType = GridType.Planter;
        }
        else if (transform.parent.name == "breedGrid")
        {
            gridType = GridType.Breed;
        }
        else if (transform.parent.name == "sellGrid")
        {
            gridType = GridType.Sell;
        }
        // set the grid slot to empty
        isEmpty = true;
    }

    // method to check if the grid slot is empty
    public bool IsEmpty(Collider2D dragged = null)
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);
        foreach (Collider2D collider in colliders)
        {
            if (collider != dragged && collider.tag == "plant")
            {
                // if it is, set the grid slot to not empty
                isEmpty = false;
                break;
            }
            else
            {
                // if it isn't, set the grid slot to empty
                isEmpty = true;
            }
        }
        return isEmpty;
    }

    // method to get the grid slot index
    public int GetIndex()
    {
        return index;
    }

    // method to get the grid type
    public GridType GetGridType()
    {
        return gridType;
    }

    // method to get the plant in the grid slot
    public GameObject GetPlant(Collider2D dragged = null)
    {
        Collider2D draggedCollider = dragged != null ? dragged : new Collider2D();
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);
        foreach (Collider2D collider in colliders)
        {
            if (collider != draggedCollider && collider.tag == "plant")
            {
                return collider.gameObject;
            }
        }
        return null;
    }
}
