using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
*   A class to hold all prefabs, sprites and configurations for the game
*/
public class config : MonoBehaviour
{
    // list of all available stem sprites, assignable in editor
    [SerializeField]
    private List<Sprite> stemSprites;
    // list of all available leaf sprites, assignable in editor
    [SerializeField]
    private List<Sprite> leafSprites;
    // list of all available flower sprites, assignable in editor
    [SerializeField]
    private List<Sprite> flowerSprites;
    
    // method to get a random sprite from the stem sprites list
    public Sprite getRandomStemSprite()
    {
        return stemSprites[Random.Range(0, stemSprites.Count)];
    }

    // method to get a random sprite from the leaf sprites list
    public Sprite getRandomLeafSprite()
    {
        return leafSprites[Random.Range(0, leafSprites.Count)];
    }

    // method to get a random sprite from the flower sprites list
    public Sprite getRandomFlowerSprite()
    {
        return flowerSprites[Random.Range(0, flowerSprites.Count)];
    }
}
