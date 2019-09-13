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
    
    public int correctScore;
    public int wrongScore;
    
    private bool isAngry;
    private GameManager gameManager;
    private StringBuilder orderedSalad;
    private List<Sprite> orderedSprites;
    private int combinations;
    private ProgressBar progressBar;
    private List<Player> playersWhoMadeMeAngry;

    void Start()
    {
        playersWhoMadeMeAngry = new List<Player>();
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
            case 3: progressBar.speed = 1f;
                break;
            case 2: progressBar.speed = 2;
                break;
            case 1: progressBar.speed = 3.5f;
                break;
            default: progressBar.speed = 2;
                break;
        }
    }

    private void DecreasePatienceLevel()
    {
        progressBar.speed += 1;
    }

    public void ValidateRecievedSalad(StringBuilder recievedSalad, Player player)
    {
        if (this.GetComponent<Salad>().VerifySalad(orderedSalad, recievedSalad))
        {
            CorrectSalad(player);
        }
        else
        {
            WrongSalad(player);
        }

        player.hasSalad = false;
        player.mySalad = null;
        player.mySaladImage.color = new Color(1, 1, 1, 0);
    }

    private void CorrectSalad(Player player)
    {
        //increase score
        if (progressBar.currentPercent < 70.0f)
        {
            //Spawn Pickup
            gameManager.SpawnPickupFor(player.playerId);
        }

        player.Score += correctScore;
        DestroyCustomer();
    }

    private void WrongSalad(Player player)
    {
        //make customer angry, decrease patience
        isAngry = true;
        playersWhoMadeMeAngry.Add(player);
        DecreasePatienceLevel();
        //penalize the player
        player.Score -= wrongScore;

    }

    private void Update()
    {
        if (progressBar.currentPercent > 99.9)
        {
            //check if angry and decrease score
            if (isAngry)
            {
                foreach (var player in playersWhoMadeMeAngry)
                {
                    player.Score -= (wrongScore * 2);
                }
            }
            else
            {
                GameObject.FindWithTag("Player").GetComponent<Player>().Score -= 20;   
            }
            DestroyCustomer();
        }
    }

    private void DestroyCustomer()
    {
        gameManager.SpawnCustomer(this.id);
        Destroy(gameObject);
    }
}
