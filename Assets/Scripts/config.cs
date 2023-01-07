using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    // list of all available stem sprites, assignable in editor
    [SerializeField]
    private List<Gene> stemGenes;
    // list of all available leaf sprites, assignable in editor
    [SerializeField]
    private List<Gene> leafGenes;
    // list of all available flower sprites, assignable in editor
    [SerializeField]
    private List<Gene> flowerGenes;
    
    // method to get a random sprite from the stem sprites list
    public Gene getRandomStemGene()
    {
        return stemGenes[Random.Range(0, stemGenes.Count)];
    }

    // method to get a random sprite from the leaf sprites list
    public Gene getRandomLeafGene()
    {
        return leafGenes[Random.Range(0, leafGenes.Count)];
    }

    // method to get a random sprite from the flower sprites list
    public Gene getRandomFlowerGene()
    {
        return flowerGenes[Random.Range(0, flowerGenes.Count)];
    }

    /**
    * methods to get the lists of sprites from each type
    */
    public List<Gene> getStemGenes()
    {
        return stemGenes;
    }

    public List<Gene> getLeafGenes()
    {
        return leafGenes;
    }

    public List<Gene> getFlowerGenes()
    {
        return flowerGenes;
    }
}
