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

    private void Update()
    {

        if (progressBar.currentPercent > 99)
        {
            gameManager.SpawnCustomer(this.id);
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
