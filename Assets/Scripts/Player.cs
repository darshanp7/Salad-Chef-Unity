using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] [Range(1, 2)] int playerId;
    public Image[] itemsHud;
    public GameObject choppingIndicator;
    public int carryingCapacity = 2;
    public float choppingTime;
    public float timeRemaining;
    
    internal string hAxis;
    internal string yAxis;
    internal string interactAxis;
    internal string chopAxis;
    private bool isAxisInUse = false;
    
    internal Stack<Dictionary<string, Sprite>> itemsCarrying;
    internal Dictionary<string, Sprite> vegetableAvailable;
    internal bool canChop;
    internal bool canPlaceOnPlate;
    internal bool canPickUpFromPlate;
    internal bool canPickUpVegetable;
    internal bool canPickUpSalad;
    internal bool hasSalad;
    internal bool canGiveSalad;
    internal bool canThrowSalad;
    
    
    private void Start()
    {
        switch (playerId)
        {
            case 1:
                hAxis = "PlayerOneH";
                yAxis = "PlayerOneV";
                interactAxis = "PlayerOneInteract";
                chopAxis = "PlayerOneChop";
                break;
            case 2:
                hAxis = "PlayerTwoH";
                yAxis = "PlayerTwoV";
                interactAxis = "PlayerTwoInteract";
                chopAxis = "PlayerTwoChop";
                break;
        }
        vegetableAvailable = new Dictionary<string, Sprite>();
        itemsCarrying = new Stack<Dictionary<string, Sprite>>();
    }

    public bool GetAxisDown(string inputAxis)
    {
        if (Input.GetAxisRaw(inputAxis) != 0)
        {
            if (isAxisInUse == false)
            {
                isAxisInUse = true;
                return isAxisInUse;
            }
        }

        if (Input.GetAxisRaw(inputAxis) == 0)
        {
            isAxisInUse = false;
            return isAxisInUse;
        }

        return false;
    }
}