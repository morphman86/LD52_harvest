using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // get all the grid slots from config
        GameObject[] gridSlots = GameObject.Find("game").GetComponent<Config>().gridSlots;
        // get the plant prefab from config
        GameObject plantPrefab = GameObject.Find("game").GetComponent<Config>().plantPrefab;
        // get a random number between 2 and the number of grid slots
        int numPlants = Random.Range(2, gridSlots.Length);
        // populate the first numPlants grid slots with plants
        for (int i = 0; i < numPlants; i++)
        {
            // get the grid slot at that index
            GameObject slot = gridSlots[i];
            // create a new plant and place at the centre of the grid slot
            Instantiate(plantPrefab, slot.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
