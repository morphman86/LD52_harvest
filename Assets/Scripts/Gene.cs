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

    public int compareStrength(Gene otherGene)
    {
        return strength - otherGene.getStrength();
    }
}