using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Breed : MonoBehaviour
{
    // when breed button is clicked, create a new plant based on the genes of the two parent plants' genes
    
    //button
    [SerializeField]
    private GameObject breedButton;
    // parent plants
    [SerializeField]
    private GameObject parent1GridSlot;
    [SerializeField]
    private GameObject parent2GridSlot;
    private GameObject parent1;
    private GameObject parent2;
    private SoundHandler soundHandler;

    // add button listener
    void Start()
    {
        breedButton.GetComponent<Button>().onClick.AddListener(breed);
        soundHandler = GameObject.Find("game").GetComponent<SoundHandler>();
    }

    // press button to breed
    public void breed(){
        // get prefab from config
        GameObject plantPrefab = GameObject.Find("game").GetComponent<Config>().plantPrefab;
        // get all the grid slots from config
        GameObject[] gridSlots = GameObject.Find("game").GetComponent<Config>().gridSlots;
        // loop through the grid slots and find the first empty one
        GameObject emptyGridSlot = null;
        foreach(GameObject gridSlot in gridSlots){
            // if the grid slot collider does not contain a plant, it is empty
            if (gridSlot.GetComponent<Grid>().IsEmpty()){
                emptyGridSlot = gridSlot;
                break;
            }
        }
        // if no empty grid slots, do nothing
        if (emptyGridSlot == null){
            // Debug.Log("No empty grid slots");
            soundHandler.PlaySound("error");
            return;
        }

        // assign the GameObject of the Collider2D inside of each parent grid slot to the parent variables
        Collider2D[] parent1Objects = Physics2D.OverlapPointAll(parent1GridSlot.transform.position);
        Collider2D[] parent2Objects = Physics2D.OverlapPointAll(parent2GridSlot.transform.position);
        foreach (Collider2D parent1Object in parent1Objects)
        {
            if (parent1Object.tag == "plant")
            {
                parent1 = parent1Object.gameObject;
                break;
            }
        }
        foreach (Collider2D parent2Object in parent2Objects)
        {
            if (parent2Object.tag == "plant")
            {
                parent2 = parent2Object.gameObject;
                break;
            }
        }
        // if not ready to breed, do nothing
        if (!(parent1 != null && parent2 != null))
        {
            // Debug.Log("Not ready to breed");
            soundHandler.PlaySound("error");
            return;
        }

        // get the config class from the scene
        Config config = GameObject.Find("game").GetComponent<Config>();
        // get the plant class from the parent plants
        Plant plant1 = parent1.GetComponent<Plant>();
        Plant plant2 = parent2.GetComponent<Plant>();
        // get the genes from the parent plants
        Gene lowerStemGene1 = plant1.getLowerStemGene();
        Gene lowerStemGene2 = plant2.getLowerStemGene();
        Gene upperStemGene1 = plant1.getUpperStemGene();
        Gene upperStemGene2 = plant2.getUpperStemGene();
        Gene leftLeafGene1 = plant1.getLeftLeafGene();
        Gene leftLeafGene2 = plant2.getLeftLeafGene();
        Gene rightLeafGene1 = plant1.getRightLeafGene();
        Gene rightLeafGene2 = plant2.getRightLeafGene();
        Gene flowerGene1 = plant1.getFlowerGene();
        Gene flowerGene2 = plant2.getFlowerGene();
        // create a new plant
        GameObject newPlant = Instantiate(plantPrefab) as GameObject;
        // get the plant class from the new plant
        Plant newPlantClass = newPlant.GetComponent<Plant>();
        // set the genes of the new plant
        newPlantClass.setLowerStemGene(getRandomGene(lowerStemGene1, lowerStemGene2));
        newPlantClass.setUpperStemGene(getRandomGene(upperStemGene1, upperStemGene2));
        newPlantClass.setLeftLeafGene(getRandomGene(leftLeafGene1, leftLeafGene2));
        newPlantClass.setRightLeafGene(getRandomGene(rightLeafGene1, rightLeafGene2));
        newPlantClass.setFlowerGene(getRandomGene(flowerGene1, flowerGene2));
        
        // set the position of the new plant
        newPlant.transform.position = emptyGridSlot.transform.position;

        parent1 = null;
        parent2 = null;

        // play sound
        soundHandler.PlaySound("success");
    }

    // get random gene from two available
    private Gene getRandomGene(Gene gene1, Gene gene2){
        // return the gene based on a random roll minus compared to the other gene
        int random = Random.Range(0, 100);
        // compare the two genes and cast to int
        int compare = (int)gene1.compareStrength(gene2);
        // return gene based on roll minus compare
        if(random - compare < 49){
            return gene1;
        } else if(random - compare < 51){
            return Gene.getRandomGene(gene1);
        } else {
            return gene2;
        }
        
    }
}
