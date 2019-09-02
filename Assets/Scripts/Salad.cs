using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class Salad : MonoBehaviour
{
    //salad = a string of concatenated vegetable strings
    //list of vegetables
    //String[] createSalad(string inputVegetable)
    //Salad getRandomSalad() // A Customer Request
    //bool verifySalad(requestedSalad, servedSalad)

    public string[] vegetableList;

    [SerializeField] [Range(0, 3)] private int maxCombinations;

        /*string[] CreateSalad(string inputVegetable)
        {
            
        }*/

    string[] requestSalad()
    {
        int[] randomIndices = new int[3];
        string[] salad = new string[3];
        for (int i = 0; i < UnityEngine.Random.Range(0, maxCombinations); i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, vegetableList.Length);
            if (!randomIndices.Contains(randomIndex)) randomIndices[i] = randomIndex;
        }

        for (int j = 0; j < randomIndices.Length; j++)
        {
            salad;
        }

        return salad;
    }

    bool verifySalad(string[] requestedSalad, string[] servedSalad)
    {
        
    }
}
