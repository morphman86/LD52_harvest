using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    // set up plant genes, two for stem, two for leaf and one for flower
    private Sprite lowerStemGene;
    private Sprite upperStemGene;
    private Sprite leftLeafGene;
    private Sprite rightLeafGene;
    private Sprite flowerGene;
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
        config config = GameObject.Find("game").GetComponent<config>();

        // get child game objects by name and assign the sprites
        lowerStem = transform.Find("stem_lower").gameObject;
        upperStem = transform.Find("stem_upper").gameObject;
        leftLeaf = transform.Find("leaf_left").gameObject;
        rightLeaf = transform.Find("leaf_right").gameObject;
        flower = transform.Find("flower").gameObject;

        // assign random sprites from the config class
        lowerStemGene = config.getRandomStemSprite();
        upperStemGene = lowerStemGene;
        leftLeafGene = config.getRandomLeafSprite();
        rightLeafGene = leftLeafGene;
        flowerGene = config.getRandomFlowerSprite();
        
        lowerStem.GetComponent<SpriteRenderer>().sprite = lowerStemGene;
        upperStem.GetComponent<SpriteRenderer>().sprite = upperStemGene;
        leftLeaf.GetComponent<SpriteRenderer>().sprite = leftLeafGene;
        rightLeaf.GetComponent<SpriteRenderer>().sprite = rightLeafGene;
        flower.GetComponent<SpriteRenderer>().sprite = flowerGene;
    }

}
