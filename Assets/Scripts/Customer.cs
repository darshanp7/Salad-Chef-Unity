using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public GameObject patienceBar;
    public Image[] hudImages;
    public int id;
    
    private bool isAngry;
    private GameManager gameManager;
    private StringBuilder orderedSalad;
    private List<Sprite> orderedSprites;
    private int combinations;
    private ProgressBar progressBar;
    
    void Start()
    {
        
        gameManager = FindObjectOfType<GameManager>();
        progressBar = patienceBar.GetComponent<ProgressBar>();
        
        orderedSalad = this.GetComponent<Salad>().OrderSalad();
        orderedSprites = this.GetComponent<Salad>().GetSaladSprites();
        combinations = this.GetComponent<Salad>().Combinations;
        for (int i = 0; i < orderedSprites.Count; i++)
        {
            hudImages[i].overrideSprite = orderedSprites[i];
            hudImages[i].color = new Color(1,1,1,1);
        }

        SetPatienceLevel();
    }

    private void SetPatienceLevel()
    {
        switch (combinations)
        {
            case 3: progressBar.speed = 1;
                break;
            case 2: progressBar.speed = 3;
                break;
            case 1: progressBar.speed = 4;
                break;
            default: progressBar.speed = 2;
                break;
        }
    }

    public void ValidateRecievedSalad(StringBuilder recievedSalad, int playerId)
    {
        Debug.Log("Ordered Salad is " + this.orderedSalad + " Recieved Salad is " + recievedSalad);
        if (this.GetComponent<Salad>().VerifySalad(orderedSalad, recievedSalad))
        {
            CorrectSalad(playerId);
        }
        else
        {
            WrongSalad(playerId);
        }
    }

    private void CorrectSalad(int playerId)
    {
        Debug.Log("Correct Salad Served by Player " + playerId);
    }

    private void WrongSalad(int playerId)
    {
        Debug.Log("Wrong Salad Served by Player " + playerId);
    }

    private void Update()
    {

        if (progressBar.currentPercent > 99.9)
        {
            gameManager.SpawnCustomer(this.id);
            Destroy(gameObject);
        }
        
    }
}
