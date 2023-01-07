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
    private GameObject parent1;
    [SerializeField]
    private GameObject parent2;
    [SerializeField]
    private GameObject prefab;

    // add button listener
    void Start()
    {
        breedButton.GetComponent<Button>().onClick.AddListener(breed);
    }

    // press button to breed
    public void breed(){
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
        GameObject newPlant = Instantiate(prefab) as GameObject;
        // get the plant class from the new plant
        Plant newPlantClass = newPlant.GetComponent<Plant>();
        // set the genes of the new plant
        newPlantClass.setLowerStemGene(getRandomGene(lowerStemGene1, lowerStemGene2));
        newPlantClass.setUpperStemGene(getRandomGene(upperStemGene1, upperStemGene2));
        newPlantClass.setLeftLeafGene(getRandomGene(leftLeafGene1, leftLeafGene2));
        newPlantClass.setRightLeafGene(getRandomGene(rightLeafGene1, rightLeafGene2));
        newPlantClass.setFlowerGene(getRandomGene(flowerGene1, flowerGene2));
        
        // set the position of the new plant
        newPlant.transform.position = new Vector3(0, 0, 0);
    }

    // get random gene from two available
    private Gene getRandomGene(Gene gene1, Gene gene2){
        // return the gene based on a random roll minus compared to the other gene
        int random = Random.Range(0, 100);
        // compare the two genes and cast to int
        int compare = (int)gene1.compareStrength(gene2);
        // return gene based on roll minus compare
        if(random - compare < 50){
            return gene1;
        } else {
            return gene2;
        }
        
    }
}
