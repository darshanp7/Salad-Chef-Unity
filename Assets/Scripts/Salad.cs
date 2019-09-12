using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class Salad : MonoBehaviour
{
    public Vegetable[] vegetableList;
    public List<Sprite> vegetableSpriteList;
    public int Combinations { get; set; }

    [SerializeField] [Range(0, 3)] private int maxCombinations;

    public StringBuilder OrderSalad()
    {
        List<int> randomIndices = new List<int>();
        StringBuilder salad = new StringBuilder();
        vegetableSpriteList.Clear();
        if (Combinations != 0) Combinations = 0;
        Combinations = UnityEngine.Random.Range(1, maxCombinations);
        for (var i = 0; i < Combinations; i++)
        {
            var randomIndex = UnityEngine.Random.Range(0, vegetableList.Length);
            if (!randomIndices.Contains(randomIndex)) randomIndices.Add(randomIndex);
        }

        foreach (var index in randomIndices)
        {
            salad.Append(vegetableList[index].name);
            vegetableSpriteList.Add(vegetableList[index].image);
        }

        return salad;
    }

    public List<Sprite> GetSaladSprites()
    {
        return vegetableSpriteList;
    }

    public bool VerifySalad(StringBuilder requestedSalad, StringBuilder servedSalad)
    {
        return requestedSalad.Equals(servedSalad);
    }
}