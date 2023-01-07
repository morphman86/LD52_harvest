using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    // set up plant genes, two for stem, two for leaf and one for flower
    private Gene lowerStemGene;
    private Gene upperStemGene;
    private Gene leftLeafGene;
    private Gene rightLeafGene;
    private Gene flowerGene;
    // get the child game objects from this game object
    private GameObject lowerStem;
    private GameObject upperStem;
    private GameObject leftLeaf;
    private GameObject rightLeaf;
    private GameObject flower;

    private string plantName;

    void Start()
    {
        if(lowerStemGene == null && upperStemGene == null && leftLeafGene == null && rightLeafGene == null && flowerGene == null){
            setStartGenes();
        }
        //set name based on genes
        // count the number of existing plants with same name
        plantName = lowerStemGene.getName() + " " + upperStemGene.getName() + " " + leftLeafGene.getName() + " " + rightLeafGene.getName() + " " + flowerGene.getName();
        gameObject.name = plantName;
    }

    // on start, get the child game objects and assign the sprites
    void setStartGenes()
    {
        // get the config class from the scene
        Config config = GameObject.Find("game").GetComponent<Config>();

        // get child game objects by name and assign the sprites
        lowerStem = transform.Find("stem_lower").gameObject;
        upperStem = transform.Find("stem_upper").gameObject;
        leftLeaf = transform.Find("leaf_left").gameObject;
        rightLeaf = transform.Find("leaf_right").gameObject;
        flower = transform.Find("flower").gameObject;

        // assign random sprites from the config class
        lowerStemGene = config.getRandomStemGene();
        upperStemGene = lowerStemGene;
        leftLeafGene = config.getRandomLeafGene();
        rightLeafGene = leftLeafGene;
        flowerGene = config.getRandomFlowerGene();
        
        lowerStem.GetComponent<SpriteRenderer>().sprite = lowerStemGene.getSprite();
        upperStem.GetComponent<SpriteRenderer>().sprite = upperStemGene.getSprite();
        leftLeaf.GetComponent<SpriteRenderer>().sprite = leftLeafGene.getSprite();
        rightLeaf.GetComponent<SpriteRenderer>().sprite = rightLeafGene.getSprite();
        flower.GetComponent<SpriteRenderer>().sprite = flowerGene.getSprite();
    }

    public string getName(){
        return plantName;
    }

    // get the genes
    public Gene getLowerStemGene(){
        return lowerStemGene;
    }

    public Gene getUpperStemGene(){
        return upperStemGene;
    }

    public Gene getLeftLeafGene(){
        return leftLeafGene;
    }

    public Gene getRightLeafGene(){
        return rightLeafGene;
    }

    public Gene getFlowerGene(){
        return flowerGene;
    }

    // set the genes

    public void setLowerStemGene(Gene gene){
        lowerStemGene = gene;
        transform.Find("stem_lower").gameObject.GetComponent<SpriteRenderer>().sprite = gene.getSprite();
    }

    public void setUpperStemGene(Gene gene){
        upperStemGene = gene;
        transform.Find("stem_upper").gameObject.GetComponent<SpriteRenderer>().sprite = gene.getSprite();
    }

    public void setLeftLeafGene(Gene gene){
        leftLeafGene = gene;
        transform.Find("leaf_left").gameObject.GetComponent<SpriteRenderer>().sprite = gene.getSprite();
    }

    public void setRightLeafGene(Gene gene){
        rightLeafGene = gene;
        transform.Find("leaf_right").gameObject.GetComponent<SpriteRenderer>().sprite = gene.getSprite();
    }

    public void setFlowerGene(Gene gene){
        flowerGene = gene;
        transform.Find("flower").gameObject.GetComponent<SpriteRenderer>().sprite = gene.getSprite();
    }

}
