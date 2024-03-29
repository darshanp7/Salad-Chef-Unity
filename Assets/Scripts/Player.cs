﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Range(1, 2)]public int playerId;
    public List<Image> itemsHud;
    public GameObject choppingIndicator;
    public GameObject plate;
    public GameObject chopBoard;
    public Image plateSprite;
    public Image chopSprite;
    public Sprite saladSprite;
    public Image mySaladImage;
    public int carryingCapacity = 2;
    public float choppingTime;
    public float timeRemaining;
    public Text scoreText;
    public Text timeRemainingText;
    
    internal string hAxis;
    internal string yAxis;
    internal KeyCode interactButton;
    internal KeyCode chopButton;
    private bool isAxisInUse = false;

    internal Plates myPlate;
    internal ChoppingBoard myChopBoard;
    internal Movement movementComponent;
    internal Queue<Item> itemsCarrying;
    internal Item vegetableAvailable;
    internal StringBuilder mySalad;
    internal bool canChop;
    internal bool canPlaceOnPlate;
    internal bool canPickUpFromPlate;
    internal bool canPickUpVegetable;
    internal bool canPickUpSalad;
    internal bool hasSalad;
    internal bool canGiveSalad;
    internal bool canThrowSalad;
    private int score;
    internal int Score
    {
        get => score;
        set
        {
            score = value;
            scoreText.text = score.ToString();
        }
    }

    private void Start()
    {
        switch (playerId)
        {
            case 1:
                hAxis = "PlayerOneH";
                yAxis = "PlayerOneV";
                interactButton = KeyCode.E;
                chopButton = KeyCode.Q;
                break;
            case 2:
                hAxis = "PlayerTwoH";
                yAxis = "PlayerTwoV";
                interactButton = KeyCode.K;
                chopButton = KeyCode.L;
                break;
        }
        choppingIndicator.gameObject.SetActive(false);
        movementComponent = GetComponent<Movement>();
        vegetableAvailable = new Item();
        itemsCarrying = new Queue<Item>();
        myPlate = plate.GetComponent<Plates>();
        myChopBoard = chopBoard.GetComponent<ChoppingBoard>();
        timeRemainingText.text = timeRemaining.ToString();
        StartCoroutine(DepleteTime());
    }
    
    IEnumerator DepleteTime()
    {
        yield return new WaitForSeconds(1);

        timeRemaining -= 1;
        timeRemainingText.text = timeRemaining.ToString();
        if (timeRemaining < 0.1)
        {
            movementComponent.canMove = false;
        }
        else
        {

            StartCoroutine(DepleteTime());
        }
    }

}