using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gene : MonoBehaviour
{
    [SerializeField]
    private string geneName;
    [SerializeField]
    private Sprite geneSprite;
    [SerializeField]
    private int strength;

    public enum GeneType {Stem, Leaf, Flower};
    public GeneType geneType;

    public string getName()
    {
        return geneName;
    }

    public Sprite getSprite()
    {
        return geneSprite;
    }

    public int getStrength()
    {
        return strength;
    }

    public GeneType getGeneType()
    {
        return geneType;
    }

    public int compareStrength(Gene otherGene)
    {
        return strength - otherGene.getStrength();
    }

    //get random gene of same type as input gene
    public static Gene getRandomGene(Gene gene)
    {
        Debug.Log("Mutating gene: " + gene.getName());
        //get config instance
        Config config = GameObject.Find("game").GetComponent<Config>();
        Gene randomGene = null;
        //get random gene of same type but not the same gene
        while(randomGene == null || randomGene.getName() == gene.getName()){
            switch(gene.getGeneType())
            {
                case GeneType.Stem:
                    randomGene = config.getRandomStemGene();
                    break;
                case GeneType.Leaf:
                    randomGene = config.getRandomLeafGene();
                    break;
                case GeneType.Flower:
                    randomGene = config.getRandomFlowerGene();
                    break;
            }
        }
        Debug.Log("Old gene type: " + gene.getGeneType() + " New gene type: " + randomGene.getGeneType());
        return randomGene;
    }
}