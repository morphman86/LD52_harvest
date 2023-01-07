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

    // on start, get the child game objects and assign the sprites
    void Start()
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

}
